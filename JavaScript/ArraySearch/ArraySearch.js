// Array indexOf()
let arr1 = [1, 2, 3, 4];
let index1 = arr1.indexOf(3);
let arr2 = [1, 2, 3, 4];
let index2 = arr2.indexOf(5);
let arr3 = [1, 2, 3, 2];
let index3 = arr3.indexOf(2);
let arr4 = ['a', 'b', 'c'];
let index4 = arr4.indexOf('b');
let arr5 = ['a', 'b', 'c'];
let index5 = arr5.indexOf('d');
let arr6 = [true, false, true];
let index6 = arr6.indexOf(false);
let arr7 = [1, 2, 3, 4];
let index7 = arr7.indexOf(3, 2);
let arr8 = [1, 2, 3, 4];
let index8 = arr8.indexOf(3, 3);
let arr9 = [1, 2, 3, 4];
let index9 = arr9.indexOf(1);
let arr10 = [1, 2, 3, 4];
let index10 = arr10.indexOf(4);

// Array lastIndexOf()
let arr11 = [1, 2, 3, 2];
let lastIndex1 = arr11.lastIndexOf(2);
let arr12 = [1, 2, 3, 4];
let lastIndex2 = arr12.lastIndexOf(3);
let arr13 = [1, 2, 3, 4];
let lastIndex3 = arr13.lastIndexOf(5);
let arr14 = ['a', 'b', 'c', 'b'];
let lastIndex4 = arr14.lastIndexOf('b');
let arr15 = ['a', 'b', 'c'];
let lastIndex5 = arr15.lastIndexOf('d');
let arr16 = [true, false, true];
let lastIndex6 = arr16.lastIndexOf(true);
let arr17 = [1, 2, 3, 2];
let lastIndex7 = arr17.lastIndexOf(2, 2);
let arr18 = [1, 2, 3, 4];
let lastIndex8 = arr18.lastIndexOf(3, 1);
let arr19 = [1, 2, 3, 1];
let lastIndex9 = arr19.lastIndexOf(1);
let arr20 = [1, 2, 3, 4];
let lastIndex10 = arr20.lastIndexOf(4);

// Array includes()
let arr21 = [1, 2, 3];
let includes1 = arr21.includes(2);
let arr22 = [1, 2, 3];
let includes2 = arr22.includes(4);
let arr23 = ['a', 'b', 'c'];
let includes3 = arr23.includes('b');
let arr24 = ['a', 'b', 'c'];
let includes4 = arr24.includes('d');
let arr25 = [true, false, true];
let includes5 = arr25.includes(false);
let arr26 = [1, 2, 3];
let includes6 = arr26.includes(2, 2);
let arr27 = [1, 2, 3];
let includes7 = arr27.includes(2, 1);
let arr28 = [1, 2, 3];
let includes8 = arr28.includes(3, -1);
let arr29 = [1, 2, 3];
let includes9 = arr29.includes(1);
let arr30 = [1, 2, 3];
let includes10 = arr30.includes(4);

// Array find()
let arr31 = [1, 2, 3, 4];
let find1 = arr31.find(x => x > 2);
let arr32 = [1, 2, 3, 4];
let find2 = arr32.find(x => x > 4);
let arr33 = [{a: 1}, {a: 2}, {a: 3}];
let find3 = arr33.find(obj => obj.a === 2);
let arr34 = [1, 2, 3, 4];
let find4 = arr34.find((x, index) => index === 2);
let arr35 = ['a', 'b', 'c'];
let find5 = arr35.find(x => x === 'b');
let arr36 = [1, 2, 3, 4];
let find6 = arr36.find(x => x % 2 === 0);
let arr37 = [1, 2, 3, 4];
let find7 = arr37.find(x => x < 0);
let arr38 = ['a', 'b', 'c'];
let find8 = arr38.find(x => x === 'a');
let arr39 = [{a: 1}, {a: 2}, {a: 3}];
let find9 = arr39.find(obj => obj.a === 3);
let arr40 = [1, 2, 3, 4];
let find10 = arr40.find((x, index) => index === 3);

// Array findIndex()
let arr41 = [1, 2, 3, 4];
let findIndex1 = arr41.findIndex(x => x > 2);
let arr42 = [1, 2, 3, 4];
let findIndex2 = arr42.findIndex(x => x > 4);
let arr43 = [{a: 1}, {a: 2}, {a: 3}];
let findIndex3 = arr43.findIndex(obj => obj.a === 2);
let arr44 = [1, 2, 3, 4];
let findIndex4 = arr44.findIndex((x, index) => index === 2);
let arr45 = ['a', 'b', 'c'];
let findIndex5 = arr45.findIndex(x => x === 'b');
let arr46 = [1, 2, 3, 4];
let findIndex6 = arr46.findIndex(x => x % 2 === 0);
let arr47 = [1, 2, 3, 4];
let findIndex7 = arr47.findIndex(x => x < 0);
let arr48 = ['a', 'b', 'c'];
let findIndex8 = arr48.findIndex(x => x === 'a');
let arr49 = [{a: 1}, {a: 2}, {a: 3}];
let findIndex9 = arr49.findIndex(obj => obj.a === 3);
let arr50 = [1, 2, 3, 4];
let findIndex10 = arr50.findIndex((x, index) => index === 3);

// Array findLast()
let arr51 = [1, 2, 3, 4];
let findLast1 = arr51.findLast(x => x > 2);
let arr52 = [1, 2, 3, 4];
let findLast2 = arr52.findLast(x => x > 4);
let arr53 = [{a: 1}, {a: 2}, {a: 3}];
let findLast3 = arr53.findLast(obj => obj.a === 2);
let arr54 = [1, 2, 3, 4];
let findLast4 = arr54.findLast((x, index) => index === 2);
let arr55 = ['a', 'b', 'c'];
let findLast5 = arr55.findLast(x => x === 'b');
let arr56 = [1, 2, 3, 4];
let findLast6 = arr56.findLast(x => x % 2 === 0);
let arr57 = [1, 2, 3, 4];
let findLast7 = arr57.findLast(x => x < 0);
let arr58 = ['a', 'b', 'c'];
let findLast8 = arr58.findLast(x => x === 'a');
let arr59 = [{a: 1}, {a: 2}, {a: 3}];
let findLast9 = arr59.findLast(obj => obj.a === 3);
let arr60 = [1, 2, 3, 4];
let findLast10 = arr60.findLast((x, index) => index === 3);

// Array findLastIndex()
let arr61 = [1, 2, 3, 4];
let findLastIndex1 = arr61.findLastIndex(x => x > 2);
let arr62 = [1, 2, 3, 4];
let findLastIndex2 = arr62.findLastIndex(x => x > 4);
let arr63 = [{a: 1}, {a: 2}, {a: 3}];
let findLastIndex3 = arr63.findLastIndex(obj => obj.a === 2);
let arr64 = [1, 2, 3, 4];
let findLastIndex4 = arr64.findLastIndex((x, index) => index === 2);
let arr65 = ['a', 'b', 'c'];
let findLastIndex5 = arr65.findLastIndex(x => x === 'b');
let arr66 = [1, 2, 3, 4];