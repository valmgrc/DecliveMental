using UnityEngine;

public class SeleccionBrujita : MonoBehaviour
{
    [Header("Animators de las Brujitas")]
    public Animator brujita1;
    public Animator brujita2;
    public Animator brujita3;

    [SerializeField] private Transform flechita;
    [SerializeField] private Transform puntoBrujita1;
    [SerializeField] private Transform puntoBrujita2;
    [SerializeField] private Transform puntoBrujita3;

    private int idActual = 0; 

    private void Start()
    {
       
        Seleccionar(idActual);
    }

    private void Update()
    {//teclado
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            idActual++;
            if (idActual > 2) idActual = 0; 
            Seleccionar(idActual);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            idActual--;
            if (idActual < 0) idActual = 2; 
            Seleccionar(idActual);
        }

        
        if (Input.GetMouseButtonDown(0)) 
        {
            
            Vector2 rayoPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayoPos, Vector2.zero);

            
            if (hit.collider != null)
            {
                
                if (hit.collider.gameObject == brujita1.gameObject) { idActual = 0; Seleccionar(0); }
                else if (hit.collider.gameObject == brujita2.gameObject) { idActual = 1; Seleccionar(1); }
                else if (hit.collider.gameObject == brujita3.gameObject) { idActual = 2; Seleccionar(2); }
            }
        }
    }

    public void Seleccionar(int ID)
    {
     
        PlayerPrefs.SetInt("BrujitaSeleccionada", ID);
        PlayerPrefs.Save();

      
        DesactivarTodas();

        switch (ID)
        {
            case 0:
                if (brujita1 != null) brujita1.SetBool("isSelected", true);
                if (flechita != null && puntoBrujita1 != null) flechita.position = puntoBrujita1.position;
                Debug.Log($"Flecha en: {flechita.position} | Punto 1 en: {puntoBrujita1.position}");
                break;

                
            case 1:
                if (brujita2 != null) brujita2.SetBool("isSelected", true);
                if (flechita != null && puntoBrujita2 != null) flechita.position = puntoBrujita2.position;
                Debug.Log($"Flecha en: {flechita.position} | Punto 1 en: {puntoBrujita2.position}");
                break;
                
            case 2:
                if (brujita3 != null) brujita3.SetBool("isSelected", true);
                if (flechita != null && puntoBrujita3 != null) flechita.position = puntoBrujita3.position;
                Debug.Log($"Flecha en: {flechita.position} | Punto 1 en: {puntoBrujita3.position}");
                break;
                
        }

        Debug.Log("Brujita seleccionada y guardada: " + ID);
    }

    private void DesactivarTodas()
    {
        if (brujita1 != null) brujita1.SetBool("isSelected", false);
        if (brujita2 != null) brujita2.SetBool("isSelected", false);
        if (brujita3 != null) brujita3.SetBool("isSelected", false);
    }
}