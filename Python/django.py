# Assuming you have a model named Customer in myapp/models.py
from myapp.models import Customer

# Create a new customer
customer = Customer.objects.create(name='John', address='Highway 37')
print(customer.id)

# Query customers
customers = Customer.objects.filter(address='Highway 37')
for customer in customers:
    print(customer.name, customer.address)
