import md5
import random
file_object = open('newuser1.txt','w')
file_sqlobj = open('newusersql1.txt','w')
for i in range(20000,50000):
	m1 = md5.new()
	ustr="test"+str(i)
	# m1.update(str(i)+"wingloong")
	passwd=str(random.randint(100000,999999))
	sql = "insert into t_user_info (id,name,password) values ('"+str(i)+"',concat('test',id),'"+passwd+"');"
 	file_object.write(ustr+","+passwd+"\r\n")
 	file_sqlobj.write(sql+"\r\n")
file_object.close()
file_sqlobj.close()
