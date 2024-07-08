#include <iostream>
#include <string>
using namespace std;

// Output
int main() {
    cout << "Hello, World!" << endl;
    return 0;
}

// Comments
// This is a single-line comment

/*
This is a
multi-line comment
*/

// Variables
int x = 5;
double pi = 3.14159;
char grade = 'A';
string name = "Alice";

// User Input
int number;
cout << "Enter a number: ";
cin >> number;
cout << "You entered: " << number << endl;

// Data Types
int intValue = 10;
double doubleValue = 3.14;
char charValue = 'C';
bool boolValue = true;

// Operators
int a = 5, b = 3;
int sum = a + b;
int difference = a - b;
double division = a / static_cast<double>(b);
int product = a * b;

// Strings
string greeting = "Hello";
cout << greeting.length() << endl;  // Output: 5

// Math
#include <cmath>
double squareRoot = sqrt(25.0);
double power = pow(2, 3);
double absolute = abs(-10);

// Conditions
int age = 20;
if (age >= 18) {
    cout << "Adult" << endl;
} else {
    cout << "Minor" << endl;
}

// Switch
int day = 3;
switch(day) {
    case 1:
        cout << "Monday" << endl;
        break;
    case 2:
        cout << "Tuesday" << endl;
        break;
    default:
        cout << "Other day" << endl;
}

// While Loop
int count = 0;
while (count < 5) {
    cout << count << endl;
    count++;
}

// For Loop
for (int i = 0; i < 5; i++) {
    cout << i << endl;
}

// Arrays
int numbers[5] = {1, 2, 3, 4, 5};
cout << numbers[0] << endl;  // Output: 1

// Structures
struct Person {
    string name;
    int age;
};
Person p1 = {"John", 30};
cout << p1.name << ", " << p1.age << endl;

// Pointers
int* ptr;
int value = 5;
ptr = &value;
cout << "Value: " << *ptr << endl;

// Functions
int add(int a, int b) {
    return a + b;
}
cout << "Sum: " << add(3, 5) << endl;

// Function Overloading
double add(double a, double b) {
    return a + b;
}
cout << "Sum: " << add(3.5, 2.5) << endl;

// Classes and Objects
class Car {
public:
    string brand;
    string model;
    int year;
    Car(string b, string m, int y) {
        brand = b;
        model = m;
        year = y;
    }
};
Car myCar("Toyota", "Corolla", 2020);
cout << myCar.brand << " " << myCar.model << " (" << myCar.year << ")" << endl;

// Inheritance
class Animal {
public:
    void eat() {
        cout << "Animal eats" << endl;
    }
};
class Dog : public Animal {
public:
    void bark() {
        cout << "Dog barks" << endl;
    }
};
Dog myDog;
myDog.eat();
myDog.bark();

// File Handling (fstream)
#include <fstream>
ofstream myfile("example.txt");
if (myfile.is_open()) {
    myfile << "Writing to file.\n";
    myfile.close();
} else {
    cout << "Unable to open file";
}

// Exceptions
try {
    int result = 10 / 0;
} catch (const std::exception& e) {
    cout << "Exception caught: " << e.what() << endl;
}

// Date and Time (ctime)
#include <ctime>
time_t now = time(0);
char* dt = ctime(&now);
cout << "Current date and time: " << dt << endl;


void function() {
    bool error = true;
    if (error) {
        throw std::runtime_error("errori agmoxvrilia");
    }
}



try {
    function();
} catch (const std::runtime_error& e) {
    std::cout << "ucnobi error: " << e.what() << std::endl;
} catch (...) {
    std::cout << "dacherilia ucnobi errori" << std::endl;
}
