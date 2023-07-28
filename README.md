# MovieStoreApi

## Genel Bakış
MovieStoreApi, film mağazası kullanıcıları için oturum açma ve token oluşturma işlevselliğini sağlar. Kullanıcılar, e-posta ve şifrelerini kullanarak oturum açabilir ve ardından API'ye erişim için bir token alabilirler.


MovieStoreApi, kullanıcılara film mağazası uygulamasında oturum açma yeteneği sunan bir API'dir. Temel amacı, kullanıcıların e-posta ve şifrelerini kullanarak oturum açmalarını ve ardından sistemdeki diğer özelliklere erişim için güvenli bir token alabilmelerini sağlamaktır. Bu token, kullanıcının kimliğini doğrulamak ve ona uygun yetkilendirmeyi sağlamak için kullanılır. Arka planda, MovieStoreApi oturum açma talebini alır, veritabanında eşleşen bir kullanıcı olup olmadığını kontrol eder ve eşleşen bir kullanıcı bulunduğunda token oluşturur. Eğer kullanıcı eşleşmezse, bir hata mesajı döner. Bu API, güvenlik, performans ve kullanılabilirlik açısından optimize edilmiştir.


Uygulama Gereksinimleri

1.Film Ekleme/Silme/Güncelleme/Listeleme

2.Müşteri Ekleme/Silme

3.Oyuncu Ekleme/Silme/Güncelleme/Listeleme

4.Yönetmen Ekleme/Silme/Güncelleme/Listeleme/

5.Film Satın Alma

6.Müşteri bazlı satın alma verisinin listelenmesi. Satın alınan filmler daha sonra sistemden silinebilir. Bu sipariş datasını etkilememeli. Bu durumu sağlamak için film verileri hard olarajk silinmemelidir. Bir Aktif-Pasif özelliği ile yönetilebilir.

7.Film türleri uygulama çalıştırıldığından varsayılan olarak yaratılabilir. Servisler ile yönetilmesine gerek yoktur.
