/*
--------------------------------------------���� 1 ������ �����
CREATE TABLE Person (
    Person_Id INT PRIMARY KEY,
    Personal_Name VARCHAR(50),
    Family_Name VARCHAR(50),
    Gender VARCHAR(10),
    Father_Id INT,
    Mother_Id INT,
    Spouse_Id INT,
    FOREIGN KEY (Father_Id) REFERENCES Person(Person_Id),
    FOREIGN KEY (Mother_Id) REFERENCES Person(Person_Id),
    FOREIGN KEY (Spouse_Id) REFERENCES Person(Person_Id)
);
*/

/*
-----------------------------------------------����� ���� 1
INSERT INTO Person (Person_Id, Personal_Name, Family_Name, Gender, Father_Id, Mother_Id, Spouse_Id)
VALUES 
(1, '���', '���', '���', NULL, NULL, 2),
(2, '���', '���', '����', NULL, NULL, 1),
(3, '����', '���', '���', 1, 2, NULL),
(4, '����', '���', '����', 1, 2, NULL),
(5, '�����', '���', '���', NULL, NULL, null),
(6, '���', '���', '����', NULL, NULL, 5),
(7, '�����', '���', '���', 5, 6, NULL),
(8, '����', '���', '����', 5, 6, NULL),
(9, '���', '���', '���', NULL, NULL, 8),
(10, '����', '���', '����', NULL, NULL, 7),
(11, '�����', '��', '���', NULL, NULL, 4),
(12, '���', '��', '����', NULL, NULL, 3);
*/

/*
-------------------------------------------����� ���� ���� ���� ������
CREATE TABLE Relative (
 Person_Id INT,
 Relative_Id INT,
 Connection_Type VARCHAR(10),
 PRIMARY KEY (Person_Id, Relative_Id),
    FOREIGN KEY (Person_Id) REFERENCES Person(Person_Id),
    FOREIGN KEY (Relative_Id) REFERENCES Person(Person_Id)
)
*/

/*
-----------------------------------------����� ���� ������
DECLARE @PersonId INT

DECLARE person_cursor CURSOR FOR
SELECT Person_Id FROM Person ORDER BY Person_Id

OPEN person_cursor
FETCH NEXT FROM person_cursor INTO @PersonId

WHILE @@FETCH_STATUS = 0
BEGIN
    
    INSERT INTO Relative(Person_Id, Relative_Id, Connection_Type)
    SELECT @PersonId, Father_Id, '��'
    FROM Person
    WHERE Person_Id = @PersonId AND Father_Id IS NOT NULL

   
    INSERT INTO Relative(Person_Id, Relative_Id, Connection_Type)
    SELECT @PersonId, Mother_Id, '��'
    FROM Person
    WHERE Person_Id = @PersonId AND Mother_Id IS NOT NULL

  
    INSERT INTO Relative (Person_Id, Relative_Id, Connection_Type)
    SELECT 
        @PersonId, 
        pOther.Person_Id,
        CASE 
            WHEN pOther.Gender = '���' THEN '��'
            ELSE '����'
        END
    FROM Person pMe
    JOIN Person pOther ON pMe.Person_Id != pOther.Person_Id
    WHERE pMe.Person_Id = @PersonId
      AND (
            (pMe.Father_Id IS NOT NULL AND pMe.Father_Id = pOther.Father_Id)
         OR (pMe.Mother_Id IS NOT NULL AND pMe.Mother_Id = pOther.Mother_Id)
          )

INSERT INTO Relative(Person_Id, Relative_Id, Connection_Type)
SELECT
    @PersonId,
    pOther.Person_Id,
    CASE 
        WHEN pOther.Gender = '���' THEN '��'
        ELSE '��'
    END
FROM Person pMe
JOIN Person pOther ON pMe.Person_Id != pOther.Person_Id
WHERE pMe.Person_Id = @PersonId
  AND (
        pOther.Father_Id = @PersonId
     OR pOther.Mother_Id = @PersonId
      )

    INSERT INTO Relative(Person_Id, Relative_Id, Connection_Type)
    SELECT 
        @PersonId, 
        Spouse_Id,
        CASE 
            WHEN Gender = '����' THEN '�� ���'
            ELSE '�� ���'
        END
    FROM Person
    WHERE Person_Id = @PersonId AND Spouse_Id IS NOT NULL

    FETCH NEXT FROM person_cursor INTO @PersonId
END

CLOSE person_cursor
DEALLOCATE person_cursor
*/

/*
-------------------------------------����� ��/�� ��� ���� ���� ��� ���� ��� 
UPDATE p
SET p.Spouse_Id = r.Person_Id
FROM Person p
JOIN Relative r  ON p.Person_Id = r.Relative_Id
WHERE p.Spouse_Id IS NULL
 AND r.Connection_Type IN ('�� ���', '�� ���')
 */


--select * FROM Person
--select * FROM Relative