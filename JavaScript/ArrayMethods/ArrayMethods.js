// push()
let arr1 = [1, 2, 3];
arr1.push(4);
arr1.push(4, 5);
arr1.push([4, 5]);
let arr2 = ['a', 'b', 'c'];
arr2.push('d');
let arr3 = [];
for (let i = 0; i < 5; i++) {
  arr3.push(i);
}
let arr4 = [1, 2];
arr4.push({a: 3});
let arr5 = [1, 2];
let arr6 = [3, 4];
arr5.push(...arr6);
let arr7 = [1, 2];
arr7.push(undefined);
let arr8 = [1, 2];
arr8.push(null);

// pop()
let arr9 = [1, 2, 3];
arr9.pop();
let arr10 = [1, 2, 3];
let removed = arr10.pop();
let arr11 = [1, 2, 3, 4, 5];
while (arr11.length) {
  arr11.pop();
}
let arr12 = [1];
arr12.pop();
let arr13 = [];
arr13.pop();
let arr14 = ['a', 'b', 'c'];
arr14.pop();
let arr15 = [{a: 1}, {b: 2}];
arr15.pop();
let arr16 = [1, [2, 3]];
arr16.pop();
let arr17 = [1, 'a', true];
arr17.pop();
let arr18 = [1, undefined];
arr18.pop();

// shift()
let arr19 = [1, 2, 3];
arr19.shift();
let arr20 = [1, 2, 3];
let removed2 = arr20.shift();
let arr21 = [1, 2, 3, 4, 5];
while (arr21.length) {
  arr21.shift();
}
let arr22 = [1];
arr22.shift();
let arr23 = [];
arr23.shift();
let arr24 = ['a', 'b', 'c'];
arr24.shift();
let arr25 = [{a: 1}, {b: 2}];
arr25.shift();
let arr26 = [[1, 2], 3, 4];
arr26.shift();
let arr27 = [1, 'a', true];
arr27.shift();
let arr28 = [undefined, 2];
arr28.shift();

// unshift()
let arr29 = [2, 3];
arr29.unshift(1);
let arr30 = [3, 4];
arr30.unshift(1, 2);
let arr31 = ['b', 'c'];
arr31.unshift('a');
let arr32 = [];
for (let i = 5; i > 0; i--) {
  arr32.unshift(i);
}
let arr33 = [1, 2];
arr33.unshift({a: 0});
let arr34 = [3, 4];
let arr35 = [1, 2];
arr34.unshift(...arr35);
let arr36 = [1, 2];
arr36.unshift(undefined);
let arr37 = [1, 2];
arr37.unshift(null);
let arr38 = [];
arr38.unshift(1);

// concat()
let arr39 = [1, 2];
let arr40 = [3, 4];
let arr41 = arr39.concat(arr40);
let arr42 = [1];
let arr43 = [2];
let arr44 = [3];
let arr45 = arr42.concat(arr43, arr44);
let arr46 = [1, [2, 3]];
let arr47 = [[4, 5]];
let arr48 = arr46.concat(arr47);
let arr49 = [1, 'a'];
let arr50 = [true, null];
let arr51 = arr49.concat(arr50);
let arr52 = [1, 2];
let arr53 = arr52.concat(arr52);
let arr54 = [];
let arr55 = [1, 2];
let arr56 = arr54.concat(arr55);
let arr57 = [1];
let arr58 = [];
let arr59 = arr57.concat(arr58);
let arr60 = ['a', 'b'];
let arr61 = ['c', 'd'];
let arr62 = arr60.concat(arr61);
let arr63 = [{a: 1}];
let arr64 = [{b: 2}];
let arr65 = arr63.concat(arr64);
let arr66 = [[1, 2]];
let arr67 = [[3, 4]];
let arr68 = arr66.concat(arr67);

// slice()
let arr69 = [1, 2, 3, 4];
let arr70 = arr69.slice(1, 3);
let arr71 = [1, 2, 3, 4];
let arr72 = arr71.slice(2);
let arr73 = [1, 2, 3, 4];
let arr74 = arr73.slice(-2);
let arr75 = [1, 2, 3, 4];
let arr76 = arr75.slice(1, -1);
let arr77 = [1, 2, 3, 4];
let arr78 = arr77.slice(0, 3);
let arr79 = [1, 2, 3, 4];
let arr80 = arr79.slice();
let arr81 = [1, 2, 3, 4];
let arr82 = arr81.slice(1, 100);
let arr83 = [1, 2, 3, 4];
let arr84 = arr83.slice(-100, 2);
let arr85 = ['a', 'b', 'c', 'd'];
let arr86 = arr85.slice(1, 3);
let arr87 = [{a: 1}, {b: 2}, {c: 3}];
let arr88 = arr87.slice(1, 2);

// splice()
let arr89 = [1, 2, 3, 4];
arr89.splice(1, 2);
let arr90 = [1, 2, 3, 4];
arr90.splice(1, 0, 'a');
let arr91 = [1, 2, 3, 4];
arr91.splice(2, 1, 'a', 'b');
let arr92 = [1, 2, 3, 4];
let removed3 = arr92.splice(1, 2);
let arr93 = [1, 2, 3, 4];
arr93.splice(0, 1);
let arr94 = [1, 2, 3, 4];
arr94.splice(2);
let arr95 = [1, 2, 3, 4];
arr95.splice(0, 2, 'a', 'b');
let arr96 = [1, 2, 3, 4];
arr96.splice(-2, 1);
let arr97 = [1, 2, 3, 4];
arr97.splice(-1);
let arr98 = ['a', 'b', 'c', 'd'];
arr98.splice(1, 2, 'x', 'y');

// indexOf()
let arr99 = [1, 2, 3, 4];
let index1 = arr99.indexOf(3);
let arr100 = [1, 2, 3, 4];
let index2 = arr100.indexOf(5);
let arr101 = [1, 2, 3, 2];
let index3 = arr101.indexOf(2);
let arr102 = ['a', 'b', 'c'];
let index4 = arr102.indexOf('b');
let arr103 = ['a', 'b', 'c'];
let index5 = arr103.indexOf('d');
let arr104 = [true, false, true];
let index6 = arr104.indexOf(false);
let arr105 = [1, 2, 3, 4];
let index7 = arr105.indexOf(3, 2);
let arr106 = [1, 2, 3, 4];
let index8 = arr106.indexOf(3, 3);
let arr107 = [1, 2, 3, 4];
let index9 = arr107.indexOf(1);
let arr108 = [1, 2, 3, 4];
let index10 = arr108.indexOf(4);

// forEach()
let arr109 = [1, 2, 3];
arr109.forEach(element => console.log(element));
let arr110 = [1, 2, 3];
arr110.forEach((element, index) => console.log(index, element));
let arr111 = [1, 2, 3];
arr111.forEach(element => {
  if (element > 1) console.log(element);
});
let arr112 = [1, 2, 3];
arr112.forEach((element, index, array) => console.log(array));
let arr113 = ['a', 'b', 'c'];
arr113.forEach(element => console.log(element));
let arr114 = [{a: 1}, {b: 2}, {c: 3}];
arr114.forEach(obj => console.log(obj));
let arr115 = [1, 2, 3];
let sum = 0;
arr115.forEach(element => sum += element);
console.log(sum);
let arr116 = [1, 2, 3];
let doubled = [];
arr116.forEach(element => doubled.push(element * 2));
console.log(doubled);
let arr117 = ['a', 'b', 'c'];
let uppercase = [];
arr117.forEach(element => uppercase.push(element.toUpperCase()));
console.log(uppercase);
let arr118 = [1, 2, 3];
arr118.forEach(element => console.log(element * 2));

// map()
let arr119 = [1, 2, 3];
let arr120 = arr119.map(x => x * 2);
let arr121 = [1, 2, 3];
let arr122 = arr121.map(x => x + 1);
let arr123 = [1, 2, 3];
let arr124 = arr123.map(x => x.toString());
let arr125 = [1, 2, 3];
let arr126 = arr125.map(x => ({value: x}));
let arr127 = ['a', 'b', 'c'];
let arr128 = arr127.map(x => x.toUpperCase());
let arr129 = [{a: 1}, {b: 2}, {c: 3}];
let arr130 = arr129.map(obj => Object.keys(obj)[0]);
let arr131 = [1, 2, 3];
let arr132 = arr131.map(x => x * x);
let arr133 = [1, 2, 3];
let arr134 = arr133.map((x, index) => x + index);
let arr135 = ['a', 'b', 'c'];
let arr136 = arr135.map((x, index) => `${x}${index}`);
let arr137 = [1, 2, 3];
let arr138 = arr137.map(x => x % 2 === 0);