using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Tareas
    {
        string id;
        int matricula;
        string titulo;
        string descripcion;
        string ape_mat;
        string calle;
        int num_calle;
        string colonia;
        int cod_postal;
        string municipio;
        string estado;
        string num_telefono;
        int carrera;
        int semestre;
        string email;
        string git;
        bool deleted;

        [JsonProperty(PropertyName = "id")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "titulo")]
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        [JsonProperty(PropertyName = "ape_pat")]
        public string Ape_Pat
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        [JsonProperty(PropertyName = "ape_mat")]
        public string Ape_Mat
        {
            get { return ape_mat; }
            set { ape_mat = value; }
        }
        [JsonProperty(PropertyName = "calle")]
        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }
        [JsonProperty(PropertyName = "num_calle")]
        public int Num_calle
        {
            get { return num_calle; }
            set { num_calle = value; }
        }
        [JsonProperty(PropertyName = "colonia")]
        public string Colonia
        {
            get { return colonia; }
            set { colonia = value; }
        }
        [JsonProperty(PropertyName = "cod_postal")]
        public int Cod_Postal
        {
            get { return cod_postal; }
            set { cod_postal = value; }
        }
        [JsonProperty(PropertyName = "municipio")]
        public string Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }
        [JsonProperty(PropertyName = "estado")]
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        [JsonProperty(PropertyName = "num_telefono")]
        public string Telefono
        {
            get { return num_telefono; }
            set { num_telefono = value; }
        }
        [JsonProperty(PropertyName = "carrera")]
        public int Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }
        [JsonProperty(PropertyName = "semestre")]
        public int Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }
        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [JsonProperty(PropertyName = "git")]
        public string Git
        {
            get { return git; }
            set { git = value; }
        }
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
