import sqlite3

# Connect to SQLite database (creates if not exists)
conn = sqlite3.connect('example.db')
cursor = conn.cursor()

# Create table
cursor.execute('''CREATE TABLE IF NOT EXISTS customers
                (id INTEGER PRIMARY KEY, name TEXT, address TEXT)''')

# Insert data
cursor.execute("INSERT INTO customers (name, address) VALUES (?, ?)", ('John', 'Highway 37'))
conn.commit()
print("Customer inserted with id:", cursor.lastrowid)

# Query data
cursor.execute("SELECT * FROM customers WHERE address=?", ('Highway 37',))
rows = cursor.fetchall()
for row in rows:
    print(row)

# Close connection
conn.close()
