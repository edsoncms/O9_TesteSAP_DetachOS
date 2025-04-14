-- SITE PROPERTY
SELECT d.name, a.*, b.*, c.*
FROM [outsystems].dbo.ossys_Site_Property_Definition a  -- DEFINICAO
    LEFT JOIN [outsystems].dbo.ossys_Site_Property b -- VALOR EFETIVO MULTI-TENANT
    ON a.ID = b.SITE_PROPERTY_DEFINITION_ID
    LEFT JOIN [outsystems].dbo.ossys_Site_Property_Shared c -- VALOR EFETIVO NORMAL
    ON a.ID = c.SITE_PROPERTY_DEFINITION_ID
    INNER JOIN [outsystems].dbo.ossys_Espace d	-- MODULO
    ON a.ESPACE_ID = d.ID
WHERE d.name LIKE '%'  -- PESQUISAR PELO NOME DO MODULO
  AND a.IS_ACTIVE = 1
  AND d.IS_ACTIVE = 1
ORDER BY d.name, a.name DESC -- ORDENAR PELOS NOMES do MODULO E DA SITE PROPERTY
