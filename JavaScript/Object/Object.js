let person = {
    firstName: 'John',
    lastName: 'Doe',
    age: 30,
    greet: function() {
        return 'Hello, ' + this.firstName + ' ' + this.lastName + '!';
    }
};
console.log(person.greet());
console.log(person.firstName);
person.email = 'john.doe@example.com';
console.log(person.email);
function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}
let newPerson = new Person('Jane', 'Smith', 25);
console.log(newPerson.firstName);
console.log(Object.keys(person));
