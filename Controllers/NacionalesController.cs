using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Cajero.Models;
namespace Cajero.Controllers
{
    public class NacionalesController : Controller
    {
        public ActionResult Nacionales(string sNumeroTarjeta, double sSaldo)
        {
            ViewBag.sNumeroTarjeta = sNumeroTarjeta;
            ViewBag.sSaldo = sSaldo;
            return View();
        }
        [HttpPost]
        public ActionResult Nacionales(string sNumeroTarjeta, double sSaldo, double cantidad)
        {
            double Saldo;
            //Se crea una instancia de la clase transacción y se le envían dos parámetros
            transaccion nuevaTransaccion = new transaccion(sNumeroTarjeta, sSaldo);
            if (cantidad > 0)
            {
                nuevaTransaccion.transferenciaNacional(cantidad);
            }
            sSaldo = nuevaTransaccion.getSaldo();
            ViewBag.sNumeroTarjeta = nuevaTransaccion.getNumTarjeta();
            ViewBag.sSaldo = nuevaTransaccion.getSaldo();
            return Redirect("../Menu/Menu?sNumeroTarjeta=" + sNumeroTarjeta + "&sSaldo=" + sSaldo);
        }
    }
}
