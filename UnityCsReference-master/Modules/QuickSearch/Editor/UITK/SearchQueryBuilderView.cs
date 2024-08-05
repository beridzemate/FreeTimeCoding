// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.Search
{
    class SearchQueryBuilderView : SearchElement, ISearchField, INotifyValueChanged<string>
    {
        public static readonly string ussClassName = "search-query-builder";

        private QueryBuilder m_QueryBuilder;
        private TextField m_TextField;
        private readonly SearchFieldBase<TextField, string> m_SearchField;
        private Action m_RefreshBuilderOff;

        int ISearchField.controlID => (int)m_SearchField.controlid;
        int ISearchField.cursorIndex => m_TextField?.cursorIndex ?? -1;
        string ISearchField.text => m_TextField?.text ?? context.searchText;
        private bool m_UseSearchGlobalEventHandler;

        string INotifyValueChanged<string>.value
        {
            get => m_QueryBuilder?.searchText;
            set
            {
                if (m_QueryBuilder == null || (m_QueryBuilder.hasOwnText && string.Equals(value, m_QueryBuilder.searchText, StringComparison.Ordinal)))
                    return;

                if (panel != null)
                {
                    var previousValue = m_QueryBuilder.searchText;
                    ((INotifyValueChanged<string>)this).SetValueWithoutNotify(value);

                    using (ChangeEvent<string> evt = ChangeEvent<string>.GetPooled(previousValue, m_QueryBuilder.searchText))
                    {
                        evt.target = this;
                        SendEvent(evt);
                    }
                }
                else
                {
                    ((INotifyValueChanged<string>)this).SetValueWithoutNotify(value);
                }
            }
        }

        internal QueryBuilder builder => m_QueryBuilder;
        internal TextField searchField => m_TextField;

        public SearchQueryBuilderView(string name, ISearchView viewModel, SearchFieldBase<TextField, string> searchField, bool useSearchGlobalEventHandler)
            : base(name, viewModel, ussClassName)
        {
            m_SearchField = searchField;
            m_UseSearchGlobalEventHandler = useSearchGlobalEventHandler;
        }

        protected override void OnAttachToPanel(AttachToPanelEvent evt)
        {
            base.OnAttachToPanel(evt);
            if (m_UseSearchGlobalEventHandler)
            {
                RegisterGlobalEventHandler<KeyDownEvent>(KeyEventHandler, 0);
            }
            else
            {
                RegisterCallback<KeyDownEvent>(OnKeyDown, useTrickleDown: TrickleDown.TrickleDown);
            }
            On(SearchEvent.RefreshBuilder, RefreshBuilder);
            On(SearchEvent.SearchContextChanged, Rebuild);

            m_TextField = m_SearchField.Q<TextField>();
            m_TextField.RemoveFromHierarchy();

            RefreshBuilder();

            m_SearchField.value = m_QueryBuilder.wordText;

            m_TextField.RegisterCallback<ChangeEvent<string>>(OnQueryChanged);
        }

        protected override void OnDetachFromPanel(DetachFromPanelEvent evt)
        {
            m_TextField?.UnregisterCallback<ChangeEvent<string>>(OnQueryChanged);
            m_TextField = null;

            m_RefreshBuilderOff?.Invoke();

            if (m_UseSearchGlobalEventHandler)
            {
                UnregisterGlobalEventHandler<KeyDownEvent>(KeyEventHandler);
            }
            else
            {
                UnregisterCallback<KeyDownEvent>(OnKeyDown);
            }
            
            Off(SearchEvent.RefreshBuilder, RefreshBuilder);
            Off(SearchEvent.SearchContextChanged, Rebuild);

            base.OnDetachFromPanel(evt);
        }

        private void Rebuild(ISearchEvent evt)
        {
            m_QueryBuilder = null;
            DeferRefreshBuilder();
        }

        private void OnQueryChanged(ChangeEvent<string> evt)
        {
            if (m_QueryBuilder != null)
            {
                m_QueryBuilder.wordText = evt.newValue;
                m_ViewModel.SetSelection();
            }
        }

        private void OnKeyDown(KeyDownEvent evt)
        {
            if (evt.imguiEvent != null && m_QueryBuilder != null)
            {
                if (KeyEventHandler(evt))
                    evt.StopImmediatePropagation();
            }
        }

        private bool KeyEventHandler(KeyDownEvent evt)
        {
            if (m_QueryBuilder == null)
                return false;

            var isHandled = m_QueryBuilder.HandleGlobalKeyDown(evt) || m_QueryBuilder.HandleKeyEvent(evt.imguiEvent);
            if (isHandled)
                Focus();
            return isHandled;
        }

        private void DeferRefreshBuilder()
        {
            m_RefreshBuilderOff?.Invoke();
            m_RefreshBuilderOff = Utils.CallDelayed(RefreshBuilder, 0.1f);
        }

        private void RefreshBuilder(ISearchEvent evt)
        {
            DeferRefreshBuilder();
        }

        private void RefreshBuilder()
        {
            Clear();

            if (m_QueryBuilder != null)
                m_QueryBuilder.Build();
            else
                m_QueryBuilder = new QueryBuilder(context, this);

            foreach (var b in m_QueryBuilder.EnumerateBlocks())
                Add(b.CreateGUI());

            if (context.options.HasAny(SearchFlags.Debug))
                Debug.LogWarning($"Refresh query builder {m_QueryBuilder.searchText} ({m_QueryBuilder.blocks.Count})");

            m_TextField?.SetValueWithoutNotify(m_QueryBuilder.wordText);

            Emit(SearchEvent.BuilderRefreshed);
        }

        void ISearchField.Focus()
        {
            m_SearchField.Focus();
        }

        VisualElement ISearchField.GetTextElement()
        {
            return m_TextField;
        }

        void INotifyValueChanged<string>.SetValueWithoutNotify(string newValue)
        {
            if (m_QueryBuilder == null || (m_QueryBuilder.hasOwnText && string.Equals(newValue, m_QueryBuilder.searchText, StringComparison.Ordinal)))
                return;
            m_QueryBuilder.searchText = newValue;
            DeferRefreshBuilder();
        }
    }
}
