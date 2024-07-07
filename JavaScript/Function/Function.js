function greet(name) {
    return 'Hello, ' + name + '!';
}
console.log(greet('Alice'));
let square = function(x) {
    return x * x;
};
console.log(square(5));
let multiply = (a, b) => a * b;
console.log(multiply(3, 4));
function sayHello(name = 'Guest') {
    return 'Hello, ' + name + '!';
}
console.log(sayHello());
function factorial(n) {
    if (n === 0 || n === 1) {
        return 1;
    } else {
        return n * factorial(n - 1);
    }
}
console.log(factorial(5));
