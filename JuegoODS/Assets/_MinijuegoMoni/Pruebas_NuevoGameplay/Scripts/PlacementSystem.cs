using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    [Space]
    [SerializeField]
    private Grid grid;

    [Header("Base de Datos Edificios")]
    [SerializeField]
    private ObjectsDatabaseSO database;
    [Space]
    [SerializeField]
    private GameObject gridVisualization;

    [SerializeField]
    private AudioClip correctPlacementClip, wrongPlacementClip;
    [SerializeField]
    private AudioSource source;

    private GridData floorData, furnitureData;

    [SerializeField]
    private PreviewSystem preview;

    private Vector3Int lastDetectedPosition = Vector3Int.zero;

    [SerializeField]
    private ObjectPlacer objectPlacer;

    IbuildingState buildingState;

    [Header("Edificios Construidos")]
    [SerializeField]
    private GameObject colegioConstruido;
    [SerializeField]
    private GameObject bibliotecaConstruido;
    [SerializeField]
    private GameObject ayuntamientoConstruido;
    [SerializeField]
    private GameObject hospitalConstruido;
    [SerializeField]
    private GameObject tiendaConstruida;
    [SerializeField]
    private GameObject viviendasContruida;
    [SerializeField]
    private GameObject centroComercialConstruido;
    [SerializeField]
    private GameObject comisariaContruida;
    [SerializeField]
    private GameObject parqueContruido;
    [SerializeField]
    private GameObject jardínConstruido;
    [SerializeField]
    private GameObject puestoLimonadaConstruido;
    [SerializeField]
    private GameObject carreterasContruido;
    [SerializeField]
    private GameObject parqueInfantilConstruido;
    [SerializeField]
    private GameObject merenderoConstruido;

    private bool tareaColegio = false;
    private bool tareabiblioteca = false;
    private bool tareaayuntamiento = false;
    private bool tareaHospital = false;
    private bool tareaTienda = false;
    private bool tareaviviendas = false;
    private bool tareaCentroComercial = false;
    private bool tareaComisaria = false;
    private bool tareaParque = false;
    private bool tareaJardín = false;
    private bool tareaPuestoLimonada = false;
    private bool tareaCarreteras = false;
    private bool tareaParqueInfantil = false;
    private bool tareaMerendero = false;

    [SerializeField]
    private Animator animatorListasTareas;

    private int activatedObjectsCount = 0;

    [Header("Tuto Mid-Game")]
    public GameObject tutoObject;
    public Animator tutoAnimator;

    public GameObject alerta;

    private List<int> destroyedBuildingIDs = new List<int>();

    [Header("Puntuación")]
    [SerializeField] private int puntuación = 0;
    public TMP_Text puntuaciónText;
    public GameObject popUpPuntuación50;
    public GameObject popUpPuntuación75;
    public GameObject popUpPuntuación100;

    public TMP_Text timer;

    private bool listaDeTareas1Completada = false;
    private bool listaDeTareas2Completada = false;
    private bool listaDeTareas3Completada = false;
    private bool listaDeTareas4Completada = false;

    public GameObject transicion;
    public GameObject fadeOut;

    public GameObject grupoMondongos_1, grupoMondongos_2, grupoMondongos_3;
    public GameObject grupoEdificios_1, grupoEdificios_2, grupoEdificios_3;
    public GameObject edificiosFinal;

    public GameObject finalMoni;

    private int cantidadCarreteras;

    public Animator cameraAnimator;

    public List<GameObject> basuras;

    public GameObject BuildingSystemParent;

    public GameObject canvas;

    public GameObject cuidadMal;

    public GameObject luzMal;
    public GameObject luzBien;
    private void Start()
    {
        gridVisualization.SetActive(false);
        floorData = new GridData();
        furnitureData = new GridData();
        animatorListasTareas.enabled = false;
        cameraAnimator.enabled = false;
    }

    public void StartPlacement(int ID)
    {
        if (destroyedBuildingIDs.Count > 0 && ID > 0 && !destroyedBuildingIDs.Contains(ID))
        {
            StartCoroutine(ActivarDesactivarObjecto(alerta));
            Debug.LogWarning("Debes reconstruir los edificios destruidos antes de colocar otros edificios.");
            return;
        }

        StopPlacement();
        gridVisualization.SetActive(true);
        buildingState = new PlacementState(ID,
                                           grid,
                                           preview,
                                           database,
                                           floorData,
                                           furnitureData,
                                           objectPlacer);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    public void StartRemoving()
    {
        StopPlacement();
        gridVisualization.SetActive(true);
        buildingState = new RemovingState(grid, preview, floorData, furnitureData, objectPlacer);
        inputManager.OnClicked += RemoveStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        buildingState.OnAction(gridPosition);

        if (buildingState is PlacementState placementState)
        {
            int objectId = placementState.ID;
            ActivateGameObjectById(objectId);

            if (objectId > 0 && destroyedBuildingIDs.Contains(objectId))
            {
                destroyedBuildingIDs.Remove(objectId);
            }
        }
    }

    private void RemoveStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        if (buildingState is RemovingState removingState)
        {
            int removedObjectId = removingState.OnRemove(gridPosition);
            if (removedObjectId > 0)
            {
                destroyedBuildingIDs.Add(removedObjectId);
                Debug.Log($"Edificio destruido con ID: {removedObjectId}");
            }
        }
    }

    private void ActivateGameObjectById(int ID)
    {
        bool objectActivated = false;

        switch (ID)
        {
            case -1:
                if (carreterasContruido != null && !carreterasContruido.activeSelf)
                {
                    cantidadCarreteras++;
                    

                    if (cantidadCarreteras == 5)
                    {
                        StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación100));
                        carreterasContruido.SetActive(true);
                        tareaCarreteras = true;
                        carreterasContruido.SetActive(true);
                        if (tareaCarreteras == true)
                        {
                            puntuación += 100;
                        }
                    }
                    
                    objectActivated = true;
                }
                break;
            case -2:
                if (carreterasContruido != null && !carreterasContruido.activeSelf)
                {
                    cantidadCarreteras++;
                    
                    if (cantidadCarreteras == 5)
                    {
                        StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación100));
                        carreterasContruido.SetActive(true);
                        tareaCarreteras = true;
                        carreterasContruido.SetActive(true);
                        if (tareaCarreteras == true)
                        {
                            puntuación += 100;
                        }
                    }

                    objectActivated = true;
                }
                break;
            case 1:
                if (colegioConstruido != null && !colegioConstruido.activeSelf)
                {
                    tareaColegio = true;
                    if (tareaColegio == true)
                    {
                        StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación50));
                        puntuación += 50;
                    }
                    colegioConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 2:
                if (bibliotecaConstruido != null && !bibliotecaConstruido.activeSelf)
                {
                    tareabiblioteca = true;
                    if (tareabiblioteca == true)
                    {
                        StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación50));
                        puntuación += 50;
                    }
                    bibliotecaConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 3:
                if (ayuntamientoConstruido != null && !ayuntamientoConstruido.activeSelf)
                {
                    tareaayuntamiento = true;
                    if (tareaayuntamiento == true)
                    {
                        StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación50));
                        puntuación += 50;
                    }
                    ayuntamientoConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 4:
                if (hospitalConstruido != null && !hospitalConstruido.activeSelf)
                {
                    tareaHospital = true;
                    if (tareaHospital == true)
                    {
                        StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación50));
                        puntuación += 50;
                    }
                    hospitalConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 7:
                if (tiendaConstruida != null && !tiendaConstruida.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación75));
                    tareaTienda = true;
                    if (tareaTienda == true)
                    {
                        
                        puntuación += 75;
                    }
                    tiendaConstruida.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 8:
                if (viviendasContruida != null && !viviendasContruida.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación75));
                    tareaviviendas = true;
                    if (tareaviviendas == true)
                    {
                        puntuación += 75;
                    }
                    viviendasContruida.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 9:
                if (centroComercialConstruido != null && !centroComercialConstruido.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación75));
                    tareaCentroComercial = true;
                    if (tareaCentroComercial == true)
                    {
                        puntuación += 75;
                    }
                    centroComercialConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 10:
                if (comisariaContruida != null && !comisariaContruida.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación75));
                    tareaComisaria = true;
                    if (tareaComisaria == true)
                    {
                        puntuación += 75;
                    }
                    comisariaContruida.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 11:
                if (parqueContruido != null && !parqueContruido.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación100));
                    tareaParque = true;
                    if (tareaParque == true)
                    {
                        puntuación += 100;
                    }
                    parqueContruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 12:
                if (parqueInfantilConstruido != null && !parqueInfantilConstruido.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación100));
                    tareaParqueInfantil = true;
                    if (tareaParqueInfantil == true)
                    {
                        puntuación += 100;
                    }
                    parqueInfantilConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 13:
                if (jardínConstruido != null && !jardínConstruido.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación100));
                    tareaJardín = true;
                    if (tareaJardín == true)
                    {
                        puntuación += 100;
                    }
                    jardínConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 14:
                if (merenderoConstruido != null && !merenderoConstruido.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación100));
                    tareaMerendero = true;
                    if (tareaMerendero == true)
                    {
                        puntuación += 100;
                    }
                    merenderoConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 15:
                if (puestoLimonadaConstruido != null && !puestoLimonadaConstruido.activeSelf)
                {
                    StartCoroutine(ActivarDesactivarObjecto(popUpPuntuación100));
                    tareaPuestoLimonada = true;
                    if (tareaPuestoLimonada == true)
                    {
                        puntuación += 100;
                    }
                    puestoLimonadaConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            default:
                Debug.LogWarning($"No GameObject assigned for ID {ID}");
                break;
        }

        if (objectActivated)
        {
            activatedObjectsCount++;
            if (activatedObjectsCount == 4 && animatorListasTareas != null && hospitalConstruido.activeSelf && colegioConstruido.activeSelf && ayuntamientoConstruido.activeSelf && bibliotecaConstruido.activeSelf && listaDeTareas1Completada == false)
            {
                listaDeTareas1Completada = true;
                animatorListasTareas.enabled = true;
                tutoObject.SetActive(true);
                tutoAnimator.Play("TutoDestruir&Flechas");
                objectActivated = false;
            }
            if(activatedObjectsCount >= 8 && animatorListasTareas != null && tiendaConstruida.activeSelf && viviendasContruida.activeSelf && centroComercialConstruido.activeSelf && comisariaContruida.activeSelf && listaDeTareas2Completada == false)
            {
                listaDeTareas2Completada = true;
                animatorListasTareas.Play("CambioTareas2_Animator");
                objectActivated = false;
                grupoMondongos_1.SetActive(true);
                grupoEdificios_1.SetActive(true);
            }
            if (activatedObjectsCount >= 11 && animatorListasTareas != null && parqueContruido.activeSelf && jardínConstruido.activeSelf && puestoLimonadaConstruido.activeSelf && listaDeTareas3Completada == false)
            {
                listaDeTareas3Completada = true;
                animatorListasTareas.Play("CambioTareas3_Animator");
                objectActivated = false;
                grupoMondongos_2.SetActive(true);
                grupoEdificios_2.SetActive(true);
            }

            if(parqueInfantilConstruido.activeSelf && merenderoConstruido.activeSelf && carreterasContruido.activeSelf && listaDeTareas4Completada == false)
            {
                for (int i = 0; i < basuras.Count; i++)
                {
                    basuras[i].SetActive(false);
                }

                listaDeTareas4Completada = true;
                listaDeTareas4Completada = true;
                objectActivated = false;
                grupoMondongos_3.SetActive(true);
                grupoEdificios_3.SetActive(true);
            }

        }
    }

    private void StopPlacement()
    {
        //soundFeedback.PlaySound(SoundType.Click);
        if (buildingState == null)
            return;
        gridVisualization.SetActive(false);
        buildingState.EndState();
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
        lastDetectedPosition = Vector3Int.zero;
        buildingState = null;
    }
    IEnumerator ActivarDesactivarObjecto(GameObject objeto)
    {
        objeto.SetActive(true);

        yield return new WaitForSeconds(2f);

        objeto.SetActive(false);
    }

    IEnumerator CambioEscena()
    {
        SelectorNivel.MoniCompletado = true;

        finalMoni.SetActive(true);

        yield return new WaitForSeconds(4f);

        Cursor.visible = false;
        transicion.SetActive(true);

        StartCoroutine(SecuenciaFinal());

    }

    IEnumerator SecuenciaFinal()
    {
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        fadeOut.SetActive(true);
        transicion.SetActive(false);
        finalMoni.SetActive(false);
        BuildingSystemParent.SetActive(false);
        cuidadMal.SetActive(false);
        luzMal.SetActive(false);
        luzBien.SetActive(true);

        cameraAnimator.enabled = true;

        yield return new WaitForSeconds(8f);

        SceneManager.LoadScene("SelecciónNivel");
    }

    private void Update()
    {
        puntuaciónText.text = puntuación.ToString();

        if (buildingState == null)
            return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        if (lastDetectedPosition != gridPosition)
        {
            buildingState.UpdateState(gridPosition);
            lastDetectedPosition = gridPosition;
        }

        

        if (listaDeTareas4Completada)
        {
            StartCoroutine(CambioEscena());
        }
    }
}