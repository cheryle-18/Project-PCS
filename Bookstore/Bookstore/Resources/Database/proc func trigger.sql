-- generate id pre order
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateIdPO()
RETURNS varchar(6)
BEGIN 
    declare ctr int;
    declare newId varchar(6);
    declare total int;

    select count(*) into total from pre_order;
    
    if total>0 then
      select substr(max(PO_ID),3)+1 into ctr from pre_order;
    else
      set ctr = 1;
    end if;
    
    set newId = (concat("PO", LPAD(ctr, 4, "0")));

    return newId;
END$$ 
DELIMITER ;

-- generate id htrans
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateIdHtrans()
RETURNS varchar(6)
BEGIN 
    declare ctr int;
    declare newId varchar(6);
    declare total int;

    select count(*) into total from htrans_purchase;
    
    if total>0 then
      select substr(max(HP_ID),3)+1 into ctr from htrans_purchase;
    else
      set ctr = 1;
    end if;
    
    set newId = (concat("HP", LPAD(ctr, 4, "0")));

    return newId;
END$$ 
DELIMITER ;

-- generate id dtrans
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateIdDtrans()
RETURNS varchar(6)
BEGIN 
    declare ctr int;
    declare newId varchar(6);
    declare total int;

    select count(*) into total from dtrans_purchase;
    
    if total>0 then
      select substr(max(DP_ID),3)+1 into ctr from dtrans_purchase;
    else
      set ctr = 1;
    end if;
    
    set newId = (concat("DP", LPAD(ctr, 4, "0")));

    return newId;
END$$ 
DELIMITER ;

-- generate invoice pre order
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateInvoicePO()
RETURNS varchar(11)
BEGIN 
    declare ctr int;
    declare invoice varchar(11);
    declare total int;

    select date_format(current_date(), "%y%m%d") into invoice;

    select count(*) into total from pre_order where substr(PO_INVOICE_NUMBER,0,6)=invoice;
    
    if total>0 then
      select substr(max(PO_INVOICE_NUMBER),8)+1 into ctr from pre_order;
    else
      set ctr = 1;
    end if;
    
    set invoice = (concat(invoice, "PO", LPAD(ctr, 3, "0")));

    return invoice;
END$$ 
DELIMITER ;

-- generate invoice transaksi
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateInvoiceTrans()
RETURNS varchar(11)
BEGIN 
    declare ctr int;
    declare invoice varchar(11);
    declare total int;

    select date_format(current_date(), "%y%m%d") into invoice;

    select count(*) into total from htrans_purchase where substr(HP_INVOICE_NUMBER,0,6)=invoice;
    
    if total>0 then
      select substr(max(HP_INVOICE_NUMBER),8)+1 into ctr from htrans_purchase;
    else
      set ctr = 1;
    end if;
    
    set invoice = (concat(invoice, "TR", LPAD(ctr, 3, "0")));

    return invoice;
END$$ 
DELIMITER ;

-- trigger kurangi stok stlh insert dtrans
DELIMITER $$
CREATE OR REPLACE TRIGGER triggerStokBuku
AFTER INSERT ON dtrans_purchase
FOR EACH ROW 
BEGIN
    declare qty int;
    declare stok int;
    declare bookId text;
    declare newStok int;

    select new.DP_QTY into qty;
    select new.DP_B_ID into bookId;
    select B_STOCK into stok from book where B_ID=bookId;

    set newStok = stok - qty;
    update book set B_STOCK = newStok where B_ID = bookId;
END$$
DELIMITER ;

-- trigger update status PO stlh update stok buku
DELIMITER $$
CREATE OR REPLACE TRIGGER triggerStatusPO
BEFORE UPDATE ON book
FOR EACH ROW 
BEGIN
    declare stok int default -1;
    declare bookId text;
    declare poId text;
    declare qty int;
    declare status int;
    declare finished int default 0;

    declare curPO CURSOR for select PO_ID, PO_QTY, PO_STATUS from pre_order where PO_B_ID=bookID;
    declare continue handler for not found set finished = 1;

    select new.B_ID into bookId;

    if(old.B_STOCK <> new.B_STOCK) then
        select new.B_STOCK into stok;
    end if;
    
    if(stok <> -1) then
        OPEN curPO;
        loop_po : LOOP
            fetch curPO into poId, qty, status;

            IF finished=1 THEN 
                LEAVE loop_po;
            END IF;

            if(stok-qty>=0 and status=1) then 
                update pre_order set PO_STATUS = 2 where PO_ID = poId;
            elseif(stok-qty<0 and status=2) then
                update pre_order set PO_STATUS = 1 where PO_ID = poId;
            end if;
        END LOOP;
        CLOSE curPO;
    end if;
END$$
DELIMITER ;


--trigger update status buku setelah insert dtrans
DELIMITER $$
CREATE OR REPLACE TRIGGER triggerBukuDtrans 
BEFORE INSERT ON dtrans_purchase 
FOR EACH ROW 
BEGIN
 DECLARE book_qty INT DEFAULT 0;
 SELECT book.B_STOCK INTO book_qty FROM book WHERE book.`B_ID` = NEW.DP_B_ID;
 
 IF book_qty - NEW.DP_QTY < 1 THEN
  UPDATE book SET book.B_STATUS = 0 WHERE book.B_ID = NEW.DP_B_ID;
 END IF;
 
 UPDATE book SET book.B_STOCK = (book_qty - NEW.DP_QTY) WHERE book.B_ID = NEW.DP_B_ID;
 
END$$

DELIMITER ;

-- generate id category
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateIdCategory()
RETURNS varchar(6)
BEGIN 
    declare ctr int;
    declare newId varchar(6);
    declare total int;

    select count(*) into total from category;
    
    if total>0 then
      select substr(max(C_ID),3)+1 into ctr from category;
    else
      set ctr = 1;
    end if;
    
    set newId = (concat("C", LPAD(ctr, 3, "0")));

    return newId;
END$$ 
DELIMITER ;


-- generate id user
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateIdUser()
RETURNS varchar(6)
BEGIN 
    declare ctr int;
    declare newId varchar(6);
    declare total int;

    select count(*) into total from users;
    
    if total>0 then
      select substr(max(U_ID),3)+1 into ctr from users;
    else
      set ctr = 1;
    end if;
    
    set newId = (concat("US", LPAD(ctr, 2, "0")));

    return newId;
END$$ 
DELIMITER ;

-- generate id employee
DELIMITER $$ 
CREATE OR REPLACE FUNCTION generateIdEmployee()
RETURNS varchar(6)
BEGIN 
    declare ctr int;
    declare newId varchar(6);
    declare total int;

    select count(*) into total from employee;
    
    if total>0 then
      select substr(max(E_ID),3)+1 into ctr from employee;
    else
      set ctr = 1;
    end if;
    
    set newId = (concat("EM", LPAD(ctr, 2, "0")));

    return newId;
END$$ 
DELIMITER ;