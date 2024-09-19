1. Para la solucion de la prueba, realicé una API con net core 8, utilicé una estructura de capas, empleando el patron repository y el patron builder en la creacion de objetos.
2. Las capas que emplean servicios tienen una clase DependencyInjection la cual tiene como objeto centralizar la configuración de los servicios que serán utilizados a lo largo de la aplicación mediante la inyección de dependencias; Utilizando un método de extension para que las disferentes capas puedan solicitar instancias de estos servicios.
3. En la capa Dominio se encuentra un folder llamado DatabaseFiles; este contiene el script de la base de datos y el diagrama de la misma.
4. Se creo un usuario: (UserName=> userdemo, Password=> RaS1809*), para efectos de crear la order; ya que se debe autenticar para poder visualizar el resumen de order y crear la misma.
5. Se utilizó sqlexpress 2022 para la base de datos
