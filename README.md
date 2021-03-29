Banka Operasyonları Simulasyonu

Hesap kayıtlarının yapılıp, hesaplar arasında para transferini sağlar. Transfer listelerini ve güncel hesap kayıtlarını listelemektedir.Herhangi bir database yapısı kullanılmamakla birlikte kayıtlar runtime cache yapısında tutulmaktadır.

-Temelde 4 endpointten oluşmaktadır;
  1- CreateAccount (Post)
  2- GetListofAccounts (Get)
  3- CreateMoneyTransaction (Post)
  4- GetListofMoneyTransactions (Get)
  
CreateAccount (Post) = Hesap Kaydı
-Bir banka hesabının oluşturulması için kullanılır.
-Unique bir hesap numarası almaktadır. (accountNumber)
-Para birimi almaktadır. (currencyCode) Bu kod yalnızca "TRY", "USD", "EUR" seçeneklerinden birisi olmalıdır.
-Hesap tutarı almaktadır. (balance) Ondalık olarak virgülden sonra 2 rakam kalacak şekilde düzenlenmiştir.

Request işlemi gerçekleştiğinde accountNumber, currencyCode için kontroller yapmaktadır. Gelen istek hatasız ise hesap kaydı yapılmaktadır. Gönderilen parametrelerde bir hata ile karşılaşılmış ise hata açıklaması ile birlikte geri dönecektir. Örn: "Account Number is not unique"

GetListofAccounts (Get) = Hesap Listesi
-Herhangi bir parametre almamaktadır. Çağrıldığında güncel hesap kayıtlarını dönmektedir.

CreateMoneyTransaction (Post) = Para Transfer Kaydı
-İki hesap arasında para transferi için kullanılır.
-Gönderici hesap numarası almaktadır. (senderAccountNumber)
-Alıcı hesap numarası almaktadır. (receiverAccountNumber)
-Gönderilecek tutar almaktadır. (amount) Ondalık olarak virgülden sonra 2 rakam kalacak şekilde düzenlenmiştir.

Request işlemi gerçekleştiğinde gönderici ve alıcı hesap numaralarına ait bir hesap kaydı olup olmadığı kontrol edilir. Göndericinin hesabında göndermek istediği tutar kadar bakiyenin olup olmadığı kontrol edilir. Gelen istek hatasız ise hesap kaydı yapılmaktadır. Gönderilen parametrelerde bir hata ile karşılaşılmış ise hata açıklaması ile birlikte geri dönecektir. Örn: "Sender or receiver account not found."

GetListofMoneyTransactions (Get) = Para Transfer Listesi
--Herhangi bir parametre almamaktadır. Çağrıldığında yapılmış olan para transferlerinin bir listesini dönmektedir.
