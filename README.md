# Unidad 3: Protocolos binarios
## Objetivo / Proceso:
Tendremos un sensor (Periferico) que por medio de protocolos binarios enviara valores a una aplicaión interactiva en Unity.
## Proceso:
- En Arduino importamos 3 librerías: 
<Wire.h> 
<Adafruit_Sensor.h> 
<Adafruit_ADXL345_U.h>
Esto con el objetivo de poder enviar los valores del movimiento (Aceleración) del sensor al programa en unity.

En los primeros void del código solo damos los detalles sobre el sensor ADXL345, además de hacer un switch con diferentes casos según la velocidad de los datos y el rango (En realidad esto es incensario, muchos de los datos no los necesitamos para nuestro objetivo principal)

En el setup iniciamos la velocidad con la que se trasmitirá el serial, y una condición con el “accel” (palabra reservada para referirse al acelerómetro) por si no se encuentra el acelerómetro. 

Luego en el Loop establecemos un evento con “getEvent” que utilizaremos para obtener los valores de la aceleración en 3 dimensiones (x,y,z) 
Para ello establecemos un arreglo de enteros con 12 espacios, estos representan los bytes, en total vamos a trasmitir 12 bytes, 4 bytes por cada valor flotante en su respectivo eje en x, y, z. 
También hacemos un condicional para que si el serial es igual a “s” envíe el arreglo de bytes actualizado.

En el programa de Unity inicializamos los arreglos que reciben la información en los puntos flotantes qx, qy, qz y el qw, a pesar de que el qw no recibe ningún valor ya que solo son 12 bytes, pero aun así debido a que el cuaternion exige 4 puntos flotantes, lo escribimos, solo que queda vacío. 

