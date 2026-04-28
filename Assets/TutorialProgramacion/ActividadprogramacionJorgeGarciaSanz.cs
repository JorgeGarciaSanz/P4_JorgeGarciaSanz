using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   public class Enemy
    {
        private string nombre;
        private float vida;
        private float ataque;
        private float defensa;

        public Enemy(string nombre, float vida, float ataque, float defensa)
        {
            Nombre = nombre;
            Vida = vida;
            Ataque = ataque;
            Defensa = defensa;
        }

        public string Nombre { get; set; }
        public float Vida { get; set; }
        public float Ataque { get; set; }
        public float Defensa { get; set; }

        //metodos

        public virtual void recibirDaño(float cantidad)
        {
            float dañoFinal = cantidad - Defensa;

            if (dañoFinal < 0)
            {
                dañoFinal = 0;
            }
            Vida = Vida - dañoFinal;

            if (Vida < 0)
            {
                Vida = 0;
            }
        }

       public virtual float Atacar(Enemy enemigo)
            {
                float dañoAtaque =0f;

                dañoAtaque = Ataque * Random.Range(0.5f, 1.5f);

                return dañoAtaque;
            }

        

        bool estaVivo()
        {
            if (Vida > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

    public class EnemigoEspecial : Enemy
    {
        private float velocidad;

        private float dañoFuegoExtra;
        

        public EnemigoEspecial(string nombre, float vida, float ataque, float defensa, float velocidad, float dañoFuegoExtra) : base(nombre, vida, ataque, defensa)
        {
            Velocidad = velocidad;
            DañoFuegoExtra = dañoFuegoExtra;
        }

        public float Velocidad { get; set; }

        public float DañoFuegoExtra { get; set; }

        public override float Atacar(Enemy enemigo){
            
            float dañoAtaque = base.Atacar(enemigo) + dañoFuegoExtra;

            return dañoAtaque;
        }


    }

    

    public void SimularAtaque(List<Enemy> enemigos)
    {
        

        foreach (Enemy enemigo in enemigos)
        {
            float daño = enemigo.Atacar(enemigo);
            enemigo.recibirDaño(daño);
            Debug.Log(enemigo.Nombre + " recibió " + daño + " de daño. Vida restante: " + enemigo.Vida);
        }

        
    }

    public static int EvaluarAtaque(float dañoBase, float defensa, float probabilidadCritico, ref int vidaActual, out bool esCritico)
    {
        float dañoFinal = dañoBase - defensa;
        if (dañoFinal < 0f)
        {
            dañoFinal = 0f;
        }
        float tiradaCritico = Random.Range(0f, 100f);

        esCritico = tiradaCritico < probabilidadCritico;

        if (esCritico)
        {
            dañoFinal *= 2.0f;
        }

        vidaActual = vidaActual - (int)dañoFinal;

        if  (vidaActual < 0)
        {
            vidaActual = 0;
        }

        return (int)dañoFinal;
    }

   
    public void Start()
    {
        List<Enemy> enemigos = new List<Enemy>();

        Enemy enemigo1 = new Enemy("Goblin", 100f, 20f, 5f);
        Enemy enemigo2 = new Enemy("Orco", 150f, 30f, 10f);
        EnemigoEspecial enemigo3 = new EnemigoEspecial("Dragón", 300f, 50f, 20f, 10f, 15f);

        enemigos.Add(enemigo1);
        enemigos.Add(enemigo2);
        enemigos.Add(enemigo3);

        SimularAtaque(enemigos);

        
    }


        
}



