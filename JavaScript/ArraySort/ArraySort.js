// Array sort()
let arr1 = [3, 8, 1, 5, 2];
arr1.sort();
console.log(arr1); 

let arr2 = ['banana', 'apple', 'orange', 'cherry'];
arr2.sort();
console.log(arr2); 

let arr3 = [10, 20, 1, 2];
arr3.sort((a, b) => a - b);
console.log(arr3); 

let arr4 = ['grape', 'pineapple', 'apple', 'strawberry'];
arr4.sort((a, b) => a.length - b.length);
console.log(arr4); 

let arr5 = [1, 10, 21, 3];
arr5.sort((a, b) => b - a);
console.log(arr5); 

let arr6 = [{ name: 'John', age: 30 }, { name: 'Jane', age: 25 }, { name: 'Doe', age: 40 }];
arr6.sort((a, b) => a.age - b.age);
console.log(arr6); 

let arr7 = [{ name: 'John', age: 30 }, { name: 'Jane', age: 25 }, { name: 'Doe', age: 40 }];
arr7.sort((a, b) => b.age - a.age);
console.log(arr7); 


let arr8 = [1, 'apple', 3, 'banana'];
arr8.sort();
console.log(arr8); 

let arr9 = [5, 2, 11, 7];
arr9.sort((a, b) => a.toString().localeCompare(b));
console.log(arr9); 

let arr10 = [5, 2, 11, 7];
arr10.sort((a, b) => b.toString().localeCompare(a));
console.log(arr10); 
