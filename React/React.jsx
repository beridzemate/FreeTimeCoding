import React, { useState, useEffect, useContext, useRef, useReducer, useCallback, useMemo } from 'react';

// Functional Component with Hooks
// const App = () => {
//   // useState example
//   const [count, setCount] = useState(0);

  // useEffect example
  useEffect(() => {
    document.title = `You clicked ${count} times`;
  }, [count]);

  // useContext example
  const ThemeContext = React.createContext('light');
  const theme = useContext(ThemeContext);

  // useRef example
  const inputRef = useRef(null);
  const focusInput = () => inputRef.current.focus();

  // useReducer example
  const initialState = { count: 0 };
  const reducer = (state, action) => {
    switch (action.type) {
      case 'increment':
        return { count: state.count + 1 };
      case 'decrement':
        return { count: state.count - 1 };
      default:
        throw new Error();
    }
  };
  const [state, dispatch] = useReducer(reducer, initialState);

  // useCallback example
  const handleClick = useCallback(() => {
    setCount(count + 1);
  }, [count]);

  // useMemo example
  const memoizedValue = useMemo(() => {
    return count * 2;
  }, [count]);

//   return (
//     <div>
//       <h1>React Hooks Example</h1>
//       <p>Count: {count}</p>
//       <button onClick={handleClick}>Increment Count</button>
//       <p>Memoized Value: {memoizedValue}</p>
//       <input ref={inputRef} type="text" />
//       <button onClick={focusInput}>Focus Input</button>
//       <p>Reducer Count: {state.count}</p>
//     </div>
//   );
// };

// export default App;


import React, { useState, useEffect, useCallback } from 'react';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';

// Example of useState
const Counter = () => {
  const [count, setCount] = useState(0);

  const increment = () => {
    setCount(count + 1);
  };

  return (
    <div>
      <h2>Counter Example</h2>
      <p>Count: {count}</p>
      <button onClick={increment}>Increment</button>
    </div>
  );
};

// Example of useEffect
const MessageComponent = ({ message }) => {
  useEffect(() => {
    // Effect to log when component mounts
    console.log('Component mounted');

    // Clean-up effect when component unmounts
    return () => {
      console.log('Component unmounted');
    };
  }, []); // Empty dependency array means this effect runs once

  return <div>{message}</div>;
};

// Example of Router, Routes, and Link
const Navigation = () => (
  <Router>
    <div>
      <h2>Navigation Example</h2>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/about">About</Link>
          </li>
          <li>
            <Link to="/contact">Contact</Link>
          </li>
        </ul>
      </nav>

      <Switch>
        <Route path="/about">
          <About />
        </Route>
        <Route path="/contact">
          <Contact />
        </Route>
        <Route path="/">
          <Home />
        </Route>
      </Switch>
    </div>
  </Router>
);

const Home = () => <div>Home Page</div>;
const About = () => <div>About Page</div>;
const Contact = () => <div>Contact Page</div>;

// Example of Loops and Rendering
const ListComponent = () => {
  const items = ['Apple', 'Banana', 'Cherry'];

  return (
    <div>
      <h2>List Example</h2>
      <ul>
        {items.map((item, index) => (
          <li key={index}>{item}</li>
        ))}
      </ul>
    </div>
  );
};

// Example of Functions and useCallback
const Greeting = ({ name }) => {
  const greet = useCallback((name) => {
    return `Hello, ${name}!`;
  }, []);

  return <div>{greet(name)}</div>;
};

// App component rendering all examples
const App = () => {
  return (
    <div>
      <h1>React Examples</h1>
      <Counter />
      <MessageComponent message="Hello, React!" />
      <Navigation />
      <ListComponent />
      <Greeting name="Alice" />
    </div>
  );
};

export default App;
