using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Business
{
	public class EmpleadoService
	{
		private List<Empleado> empleados;

		public EmpleadoService()
		{
			empleados = new List<Empleado>();
		}

		public bool AgregarEmpleado(Empleado empleado)
		{
			// Verificar duplicados por Número de Empleado o DNI
			if (empleados.Any(e => e.NumeroEmpleado == empleado.NumeroEmpleado || e.Dni == empleado.Dni))
			{
				throw new InvalidOperationException("Ya existe un empleado con el mismo Número de Empleado o DNI.");
			}

			empleados.Add(empleado);
			return true;
		}

		public bool EliminarEmpleado(int numeroEmpleado)
		{
			var empleado = empleados.FirstOrDefault(e => e.NumeroEmpleado == numeroEmpleado);
			if (empleado != null)
			{
				empleados.Remove(empleado);
				return true;
			}

			throw new KeyNotFoundException("No se encontró un empleado con el Número de Empleado especificado.");
		}

		public bool ActualizarEmpleado(Empleado empleadoActualizado)
		{
			var empleadoExistente = empleados.FirstOrDefault(e => e.NumeroEmpleado == empleadoActualizado.NumeroEmpleado);

			if (empleadoExistente == null)
			{
				throw new KeyNotFoundException("No se encontró un empleado con el Número de Empleado especificado.");
			}

			// Validar que no se duplique el DNI con otro empleado
			if (empleados.Any(e => e.Dni == empleadoActualizado.Dni && e.NumeroEmpleado != empleadoActualizado.NumeroEmpleado))
			{
				throw new InvalidOperationException("Ya existe un empleado con el mismo DNI.");
			}

			empleadoExistente.Nombre = empleadoActualizado.Nombre;
			empleadoExistente.Apellido = empleadoActualizado.Apellido;
			empleadoExistente.Dni = empleadoActualizado.Dni;
			empleadoExistente.Email = empleadoActualizado.Email;
			empleadoExistente.Sector = empleadoActualizado.Sector;

			return true;
		}

		public List<Empleado> ObtenerEmpleados()
		{
			return empleados;
		}
	}
}
