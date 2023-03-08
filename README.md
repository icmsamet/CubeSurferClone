# CubeSurferClone
 
Merhaba!

Bu projem, popüler mobil oyunu "Cube Surfer"ın bir klonunu Unity oyun motoru kullanarak oluşturduğum bir projedir. Bu projenin amacı, Unity ile farklı mekanikler denemek ve aynı zamanda eğlenceli bir oyun yapmak için pratik yapmaktı.

## Oyun Hakkında
Cube Surfer, oyuncuların bir küp üzerinde hareket ettikleri ve yoldaki engelleri aşarak küpü daha da büyüttükleri bir sonsuz koşu oyunudur. Oyuncular, küpü hareket ettirmek için kaydırma hareketlerini kullanırken, yoldaki engellere çarpmadan mümkün olduğunca uzun bir mesafe kat etmeye çalışırlar.

## Used Assets
- Dotween Pro [LINK](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416)
- Odin Inspector [LINK](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)
- Dreamteck Spline [LINK](https://assetstore.unity.com/packages/tools/utilities/dreamteck-splines-61926)
- Joystick Pack [LINK](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)

## Proje Hakkında
Bu proje, Unity oyun motoru kullanılarak geliştirildi ve C# programlama dili kullanıldı. Oyunun modelleri Unity içerisindeki basit objeler kullanıldı, oyuncuların küpü hareket ettirmesi ve engellere çarpmadan mümkün olduğunca yüksek bir mesafeye çıkmalarının gerektiği gibi basit bir fikre dayanıyor.
Proje klasöründe, tüm oyunun kaynak kodları ve kullanılan varlıklar bulunmaktadır. Oyunu Unity ile açarak, proje dosyalarını inceleyebilir ve oyuna yeni özellikler eklemek veya değiştirmek için düzenleyebilirsiniz. Oyun içerisinde 2 adet "Level Desing" sürecini kısaltmak için editör bulunmaktadır. Bunlardan biri Toplanabilir Objeler ve Engel Objeleri içindir. 
![EditorGif](https://user-images.githubusercontent.com/76155610/223783092-4f793f8d-1083-459b-86eb-d02fe1d5ddb4.gif)

## Collect Editor
Bu editor'ün çalışması için sahne içerisinde bir "Spline" olması gerekiyor.

![Collect Editor Notice!](https://user-images.githubusercontent.com/76155610/223788465-1de41cc8-6f97-4e5f-b218-c90cf9516c5f.png)

Sahneye bir "Spline" eklendikten sonra editör kullanılabilir hale geliyor.

![Collect Editor](https://user-images.githubusercontent.com/76155610/223789167-e442ae06-4e1d-49c9-9eca-8b7fa6af6d9a.png)

"Chose Collect Color" ile seçilen renk ile bir toplanabilir obje ekleyebiliriz sahneye.
Objeyi sahneye ekledikten sonra, eklenen obje verileri ile bir sekme olarak geliyor.

![Collect Tab](https://user-images.githubusercontent.com/76155610/223792791-9714f27d-9002-41fd-9645-5e0ee9eb233a.png)

Buradan objenin rengini,pozisyonunu ve rotasyonunu değiştirebiliriz.
Istersek toplu seçim yapıp toplu bir değişiklik de yapabiliriz.

![Collect Editor Stack](https://user-images.githubusercontent.com/76155610/223793316-baab11db-9ac4-440e-8a15-577d3e97f0a2.png)

## Obstacle Editor
Bu editor'ün çalışması için sahne içerisinde bir "Spline" olması gerekiyor.

![Obstacle Editor Notice!](https://user-images.githubusercontent.com/76155610/223794073-8da9e2da-31b8-483b-a510-119ea496b9ec.png)

Sahneye bir "Spline" eklendikten sonra editör kullanılabilir hale geliyor.

![Obstacle Editor](https://user-images.githubusercontent.com/76155610/223794210-de6b108a-41c5-4d8b-ac32-cc56cdd42e1c.png)

"Chose Obstacle Type" ile seçilen tip ile bir engel objesi eklebiliriz sahneye.
Objeyi sahneye ekledikten sonra, eklenen obje verileri ile bir sekme olarak geliyor.

![Obstacle Tab](https://user-images.githubusercontent.com/76155610/223796097-f88d7859-aa60-4bfb-a98a-9de02b9b4e79.png)

Buradan objenin rengini,pozisyonunu,rotasyonunu ve tipini değiştirebiliriz.
Istersek toplu seçim yapıp toplu bir değişiklik de yapabiliriz.

![Obstacle Editor Stack](https://user-images.githubusercontent.com/76155610/223796966-b25c0b22-767e-44d2-80d3-cd8f00d5f53d.png)

## Level

Editörden herhangi bir obje eklendikten sonra "Spline" objesinin üstüne "Level" kompenenti ekleniyor.
Bu kompenent üzerinden,bölüm sonu ekleyebilir ve bölümün numarasını değiştirebiliriz.

![Ekran görüntüsü 2023-03-08 212827](https://user-images.githubusercontent.com/76155610/223802907-3885e6ae-e64d-4ba0-9d5e-1cde1b983c77.png)

## Level End

Level End üzerinden bölüm sonunu düzenleyebiliriz.

![Ekran görüntüsü 2023-03-08 213120](https://user-images.githubusercontent.com/76155610/223803608-c3ad4f42-6d73-4bae-bf8e-8e20b6cf51f5.png)

Üzerindeki değişkenler ile bölüm sonunu düzenleyebiliriz.

![Level](https://user-images.githubusercontent.com/76155610/223804748-83843ada-8e4a-4efc-81b6-9b84cd797041.gif)
