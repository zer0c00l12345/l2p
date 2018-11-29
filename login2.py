import getpass 
import sys



loginVerify = input(" Have you logged in before? ")
if loginVerify == 'yes' or loginVerify =='Yes':
	UserName = input(" Please Enter Your User Name ")
else:
	print(" Please Create an Account ")
	sys.exit(0)


UserNameArray = ['bill']
UserPasswordArray = ['1q']


# Check user name against array
if UserName in UserNameArray:
	UserPassword = input
	UserPassword = getpass.getpass(" Please Enter your Password ")
else:
	print(" Access Denied ") 

# Check Password Against Array
if UserPassword in UserPasswordArray:
	print(" Access granted! ")
else:
	print(" Access Denied! ")


