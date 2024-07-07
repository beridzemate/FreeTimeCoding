import pymongo

# Connect to MongoDB
client = pymongo.MongoClient("mongodb://localhost:27017/")
db = client["mydatabase"]
collection = db["customers"]

# Insert document
customer_data = { "name": "John", "address": "Highway 37" }
insert_result = collection.insert_one(customer_data)
print(insert_result.inserted_id)

# Find document
query = { "address": "Highway 37" }
result = collection.find(query)
for document in result:
    print(document)
