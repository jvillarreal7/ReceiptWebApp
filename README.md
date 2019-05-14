# ReceiptWebApp
Demo de una aplicación web de gestión de recibos en ASP.NET MVC.

# Notas:
- **Proveedores y tipos de cambio son entidades del modelo.**

Existe una migración para poblarlas con datos dummy pero en caso que se requiera esto se puede hacer directamente sobre la base de datos creada:
~~~~
INSERT INTO Providers (Name) VALUES ('Axtel');
INSERT INTO Providers (Name) VALUES ('Coca-Cola');
INSERT INTO Providers (Name) VALUES ('Movistar');
INSERT INTO Providers (Name) VALUES ('Nintendo');

INSERT INTO CurrencyTypes (Name) VALUES ('USD');
INSERT INTO CurrencyTypes (Name) VALUES ('MXN');
INSERT INTO CurrencyTypes (Name) VALUES ('GBP');
INSERT INTO CurrencyTypes (Name) VALUES ('EUR');
~~~~

- **Plugins externos utilizados:**
1. [SweetAlert2](https://sweetalert2.github.io/)
2. [DataTables](https://datatables.net/)
3. [Moment.js](https://momentjs.com/)
4. [Bootstrap Datetimepicker](https://eonasdan.github.io/bootstrap-datetimepicker/)
