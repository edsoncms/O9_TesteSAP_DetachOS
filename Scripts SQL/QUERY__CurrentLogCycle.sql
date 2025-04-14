-- Current Log Cycle:

DECLARE @input_date AS DATE = {d'2019-08-02'};		-- Data a ser testada

-- 
DECLARE @curr_date AS DATE = GETDATE();				-- Data atual
DECLARE @reference_date AS DATE = {d'2000-01-01'};	-- Data de referência (FIXA)
DECLARE @cycle_size AS INT = (SELECT [VAL] FROM [outsystems].[dbo].[ossys_Parameter] WHERE [NAME] = 'LogServer.Db.CycleSize');
DECLARE @cycle_period AS INT = 7;					-- Periodo Padrao: 1 semana

SELECT	@input_date "INPUT-DATE",
		((DATEDIFF(DAY, @reference_date, @input_date) / @cycle_period) % @cycle_size) "INPUT-DATE-CYCLE", 
		@curr_date "CURR-DATE",
		((DATEDIFF(DAY, @reference_date, @curr_date) / @cycle_period) % @cycle_size)  "CURR-DATE-CYCLE";

-- END --

-- PESQUISAR CONFIGURAÇÕES DE LOGS:

-- SELECT * FROM [outsystems].[dbo].[ossys_Parameter] WHERE [NAME] LIKE 'LogServer%';