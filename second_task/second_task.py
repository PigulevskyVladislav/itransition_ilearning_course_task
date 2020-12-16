import hashlib
import os

dir = os.listdir()
for fileName in dir:
	content = open(fileName).read().encode()
	print(fileName, end=' ')
	print(hashlib.sha3_256(content).hexdigest())
