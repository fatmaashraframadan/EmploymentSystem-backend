use EmploymentSystem6;

SELECT * FROM [identity].AspNetUsers;
SELECT * FROM [identity].AspNetUserRoles;
SELECT * FROM [identity].AspNetRoles;

SELECT r.Name
FROM [identity].AspNetUsers u
INNER JOIN [identity].AspNetUserRoles ur ON u.Id = ur.UserId
INNER JOIN [identity].AspNetRoles r ON ur.RoleId = r.Id
WHERE u.Email = 'applicant2@test.com';

Create DATABASE EmploymentSystem6;

SELECT * FROM [identity].AspNetUsers;
