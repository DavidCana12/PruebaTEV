select *from CLIENTES order by NOM_CLIENTE asc 
select *from CLIENTES where LOC_CLIENTE = 'Madrid'
select *from CLIENTES where CP_CLIENTE like '41[^2]%'
select *from CLIENTES where COD_CLIENTE < 10 and NOM_CLIENTE like 'a%'
select count(*) as Cantidad, LOC_CLIENTE    from CLIENTES group by LOC_CLIENTE
delete from CLIENTES where NOM_CLIENTE  like 'z%' and NOM_CLIENTE like '%z'
update CLIENTES set CP_CLIENTE= '28001'  where LOC_CLIENTE = 'Madrid'
select * from CLIENTES inner join VENTAS on CLIENTES.COD_CLIENTE = VENTAS.COD_CLIENTE where IMPORTE != 0
select * from CLIENTES inner join VENTAS on CLIENTES.COD_CLIENTE = VENTAS.COD_CLIENTE
update VENTAS  set IMPORTE = 0 select  *from VENTAS inner join   CLIENTES on CLIENTES.COD_CLIENTE = VENTAS.COD_CLIENTE where  NOM_CLIENTE like '%a%'
