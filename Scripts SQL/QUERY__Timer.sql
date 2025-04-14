-- TIMERS
SELECT c.name, b.*, a.*
    FROM [outsystems].dbo.ossys_Cyclic_Job_Shared a
    INNER JOIN [outsystems].dbo.ossys_Meta_Cyclic_Job b
    ON a.META_CYCLIC_JOB_ID = b.ID
    INNER JOIN [outsystems].dbo.ossys_Espace c	
    ON b.ESPACE_ID = c.ID
WHERE c.name LIKE '%'  -- PESQUISAR PELO NOME DO MODULO
  AND b.IS_ACTIVE = 1
  AND c.IS_ACTIVE = 1
ORDER BY a.LAST_RUN DESC -- ORDENAR PELO QUE RODOU POR ULTIMO