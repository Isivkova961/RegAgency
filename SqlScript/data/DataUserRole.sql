USE RecrAgency
GO
INSERT [Role] ([Name])
VALUES ('Employee'), 
('Jobseeker'), 
('Admin')

--Password = '123'
INSERT [User] ([UserName], [Password], [RoleId])
SELECT 'admin', 'AIdKypBsR6V0DnkJ2pF18sE9QDwk3lDOjOOQmvFCKrMik8x4yRt+o0JJNSUHpAyRLQ==', r.[id]
FROM [Role] r
WHERE r.[Name] = 'Admin'



