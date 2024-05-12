Configuración del Web Server
--------------------------------
Luego de conectarnos haciendo `SSH` a través del `Bastion Host A` empezamos con la configuración. <br>
Lo primero es instalar las herramientas necesarias para hacer el montaje del EFS y crear los directorios donde se va a montar: <br>
```
sudo yum install -y amazon-efs-utils
sudo mkdir -p /mnt/efs/wordpress
```