-- Database Connections:
SELECT * FROM OSSYS_DBCONNECTION;

-- Database Catalogs:
SELECT * FROM OSSYS_DBCATALOG;

-- REST Consumidores
SELECT A.NAME, B.*
  FROM [outsystems].[dbo].[ossys_Espace] A
  INNER JOIN [outsystems].[dbo].[OSSYS_REST_WEB_REFERENCE] B
  ON A.ID = B.ESPACE_ID
WHERE ( A.IS_ACTIVE = 1 )
  AND ( B.IS_ACTIVE = 1 );


-- REST Expositores
SELECT A.NAME, C.*
  FROM [outsystems].[dbo].[ossys_Espace] A
  LEFT JOIN [outsystems].[dbo].[OSSYS_REST_EXPOSE] C
  ON A.ID = C.ESPACE_ID
WHERE ( A.IS_ACTIVE = 1 )
  AND ( C.IS_ACTIVE = 1 );

  
-- SOAP Consumidores
SELECT A.NAME, B.*
  FROM [outsystems].[dbo].[ossys_Espace] A
  INNER JOIN [outsystems].[dbo].[ossys_Web_Reference] B
  ON A.ID = B.ESPACE_ID
WHERE ( A.IS_ACTIVE = 1 )
  AND ( B.IS_ACTIVE = 1 );


-- REST Expositores
SELECT A.NAME, B.*
  FROM [outsystems].[dbo].[ossys_Espace] A
  INNER JOIN [outsystems].[dbo].[ossys_Web_Service] B
  ON A.ID = B.ESPACE_ID
WHERE ( A.IS_ACTIVE = 1 )
  AND ( B.IS_ACTIVE = 1 );

-- PARAMETER
SELECT * FROM ossys_Parameter ORDER BY [name];