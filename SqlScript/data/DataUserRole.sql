USE RecrAgency
GO
INSERT [Role] ([Name])
VALUES ('Employee'), 
('Jobseeker'), 
('Admin')

INSERT [User] ([UserName], [Password], [RoleId])
SELECT 'admin', '123qwe', r.[id]
FROM [Role] r
WHERE r.[Name] = 'Admin'



