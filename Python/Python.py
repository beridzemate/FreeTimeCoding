# Output
print('Hello, world!')  # Hello, world!

# Variables
x = 5
y = 'Hello'
a = 10
b = 'Python'
PI = 3.14159
MAX_SIZE = 100

# Functions
def greet(name):
    return 'Hello, ' + name + '!'
print(greet('Alice'))  # Hello, Alice

square = lambda x: x * x
print(square(5))  # 25

multiply = lambda a, b: a * b
print(multiply(3, 4))  # 12

def say_hello(name='Guest'):
    return 'Hello, ' + name + '!'
print(say_hello())  # Hello, Guest

def factorial(n):
    if n == 0 or n == 1:
        return 1
    else:
        return n * factorial(n - 1)
print(factorial(5))  # 120

# Conditional Statements
x = 10
if x > 5:
    print('x is greater than 5')  # x is greater than 5
elif x == 5:
    print('x is equal to 5')
else:
    print('x is less than 5')

# Loops
# For Loop
for i in range(1, 5):
    print(i)  # 1, 2, 3, 4

# For In Loop (Iterating over a list)
fruits = ['apple', 'banana', 'cherry']
for fruit in fruits:
    print(fruit)  # apple, banana, cherry

# For Of Loop (Iterating over a string)
message = 'Hello'
for char in message:
    print(char)  # H, e, l, l, o

# While Loop
num = 1
while num <= 5:
    print(num)  # 1, 2, 3, 4, 5
    num += 1

# Lists
numbers = [1, 2, 3, 4, 5]
print(numbers)  # [1, 2, 3, 4, 5]

# Adding elements to a list
numbers.append(6)
print(numbers)  # [1, 2, 3, 4, 5, 6]

# Removing elements from a list
removed_element = numbers.pop()
print(removed_element)  # 6
print(numbers)  # [1, 2, 3, 4, 5]

# Dictionaries
person = {
    'firstName': 'John',
    'lastName': 'Doe',
    'age': 30
}
print(person['firstName'])  # John

# Adding a new key-value pair
person['email'] = 'john.doe@example.com'
print(person['email'])  # john.doe@example.com

# Sets
set1 = {'apple', 'banana', 'cherry'}
print(set1)  # {'apple', 'banana', 'cherry'}

# Adding elements to a set
set1.add('orange')
print(set1)  # {'apple', 'banana', 'cherry', 'orange'}

# Removing elements from a set
set1.remove('banana')
print(set1)  # {'apple', 'cherry', 'orange'}

# JSON
import json

# JSON parsing
json_data = '{"name": "John", "age": 30}'
parsed_data = json.loads(json_data)
print(parsed_data['name'])  # John

# JSON encoding
data = {'name': 'Jane', 'age': 25}
json_string = json.dumps(data)
print(json_string)  # {"name": "Jane", "age": 25}

# Date and Time
from datetime import datetime, timedelta

# Current date and time
current_datetime = datetime.now()
print(current_datetime)

# Formatting date
formatted_date = current_datetime.strftime('%Y-%m-%d %H:%M:%S')
print(formatted_date)

# Date arithmetic
next_week = current_datetime + timedelta(days=7)
print(next_week)