insert into AspNetRoles values('Admin','�t�κ޲z��')
insert into AspNetRoles values('Guest','�@��ϥΪ�')
insert into AspNetUsers values('e2279912-e3b1-4ad3-b8e0-613fd3f2f3f6',getdate(),'engels@champtron.com',1,'AHVA7OY/WUmTKOoem5+DWFX2YkBt770vNTIsYlJui58p5wanjH8SVTDYcUGbNNV4DQ==','9180a01d-0b26-4c13-8c9d-4691f0683622',null,0,0,null,0,0,'engels',1)
insert into AspNetUserRoles values('e2279912-e3b1-4ad3-b8e0-613fd3f2f3f6','Admin')


insert into [Account.SideBarType] values(0,'�t�αb���޲z')
insert into [Account.ControllerName] values('Roles','����޲z',0,1)
insert into [Account.ControllerName] values('Account','�b���޲z',0,2)
insert into [Account.AuthorizeRoles] values('Admin','Roles')
insert into [Account.AuthorizeRoles] values('Admin','Account')