DELIMITER $$
DROP PROCEDURE IF EXISTS generateIdPenerbit$$
CREATE PROCEDURE generateIdPenerbit(OUT idPenerbit VARCHAR(10))
BEGIN
	DECLARE ctr INT(5);
	DECLARE keluar VARCHAR(10);
	SELECT COUNT(P_ID)+1 INTO ctr FROM publisher;
	SET keluar = CONCAT('P',LPAD(ctr,3,0));
	SET idPenerbit = keluar;
	SELECT idPenerbit;
END$$
DELIMITER ;

