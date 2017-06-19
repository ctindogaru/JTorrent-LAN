# JTorrent-LAN - simple file-sharing

Simply transfer files between computers connected at the same network.  

What do I need?
For the database I used Microsoft SQL Server 2008 with SQL Server Management Studio 2014.  
The database contains 2 tables: one for the users, one for the uploaded files.  
You will need a computer with database configured which will be the server and at least one client which will be the client. Multiple clients are also accepted.  
The server can upload the files and make them public and the clients can connect to the server and download these files. (file can be documents, images etc.)

Future implementation:
Client-to-Client transfer, currently only Server-to-Client is supported.