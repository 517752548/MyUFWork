file_object = open('user.txt')
file_outupdate = open('update.sql','w')
for line in file_object:
    allstr=line.split(',')
    file_outupdate.write("update t_user_info set password=\'"+allstr[1]+"\' where name=\'"+allstr[0]+"\';\r\n")
file_outupdate.close()