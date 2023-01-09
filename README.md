# TP Final - Sistema de turnos para una clínica 
> Proyecto final para la materia Programación III - UTN FRGP 

## Propuesta 
Se requiere una aplicación para administrar la asignación de turnos, pacientes y médicos de una clínica médica.

En el sistema se cargarán los médicos, que estarán asociados a una o más especialidades y a un turno de trabajo, y los pacientes con toda su información personal. Los turnos de trabajo serán administrados por el usuario y podrán cargar el horario de entrada y salida que demanden; pudiendo haber tantos turnos de trabajo como se necesite.

La funcionalidad central de la aplicación es gestionar los tiempos de los especialistas a partir de la asignación de turnos a los pacientes.

Para dar de alta un turno el usuario deberá seleccionar un paciente (que deberá estar previamente cargado), y seleccionar una especialidad. A partir de la especialidad seleccionada el sistema debería proponerle algunas opciones en cuanto a horarios y médicos. Por ejemplo, si se elige “Dentista” el sistema debería sugerir tres horarios posibles con su respectivo médico. El usuario podrá elegirlo u optar por seguir cargando el formulario de manera manual. El siguiente dato a cargar es el médico, una vez allí se podrá seleccionar un día y se deberán mostrar los horarios disponibles del médico seleccionado en el día seleccionado. No puede existir más de un turno para el mismo médico, el mismo día a la misma hora. Lo mismo para el paciente. No se pueden dar de alta turnos vencidos. Por último, se deben cargar las observaciones que corresponden a la causa por la cual el paciente solicita el turno. Una vez dado de alta el turno, se le asigna un número y se envía por mail la confirmación del mismo con los datos correspondientes al paciente (debe tener cargado correctamente el correo electrónico en el sistema).

Los tiempos de los turnos se proponen se configuren de una hora de duración (de 10 a 11, de 11 a 12, etc.).

La aplicación debe manejar seguridad y perfiles de acceso. Por un lado administrador, que puede ver y manipular todo, por otro lado recepcionista, que puede administrar pacientes y médicos y dar de alta turnos, y finalmente médicos que sólo podrán ver sus turnos asociados y modificarlos para agregar las observaciones sobre el diagnóstico del paciente.

## Imágenes del proyecto
![login](https://user-images.githubusercontent.com/110779735/211424711-0a077353-d6d8-402d-949c-c1d714c69883.png)
![inicio](https://user-images.githubusercontent.com/110779735/211424724-4a20d290-370b-409a-ad77-bef6f9832add.png)
![lista-turnos](https://user-images.githubusercontent.com/110779735/211424737-f100f43c-e7d0-4067-ab45-73e5abbe0f88.png)
![agregar-turno](https://user-images.githubusercontent.com/110779735/211424744-52e1bd83-a09b-42d6-aeda-13d6841453d9.png)
![lista-paciente](https://user-images.githubusercontent.com/110779735/211424753-bc4dff1c-2773-446d-9c9b-dfad48628781.png)
![alta-paciente](https://user-images.githubusercontent.com/110779735/211424755-dbf9ebb7-c1c3-4ff3-ba67-cbc5832671e7.png)
![permisos](https://user-images.githubusercontent.com/110779735/211424765-d4e987aa-e904-4406-bea1-a2fb38971184.png)
