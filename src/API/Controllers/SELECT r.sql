SELECT r.Name
FROM [identity].AspNetUsers u
INNER JOIN [identity].AspNetUserRoles ur ON u.Id = ur.UserId
INNER JOIN [identity].AspNetRoles r ON ur.RoleId = r.Id
WHERE u.Email = 'applicanr2@test.com';


SELECT * FROM [identity].AspNetUsers;
SELECT * FROM [identity].AspNetUserRoles;
SELECT * FROM [identity].AspNetRoles;