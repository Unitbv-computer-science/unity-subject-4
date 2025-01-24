using Assets.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Private Fields
    // Camera din scenă.
    private Camera _camera;
    #endregion


    #region Serialized Fields
    // Lista de sloturi din scenă.
    [SerializeField] private List<Slot> _Slots;

    // Cele 8 piese de puzzle prezente la începutul jocului.
    [SerializeField] private List<PuzzlePiece> _VisiblePieces;

    // Prefabul piesei 9 de puzzle.
    [SerializeField] private PuzzlePiece _LastPiece;

    // Obiectul părinte al pieselor de puzzle.
    [SerializeField] private GameObject _PuzzlePiecesContainer;
    #endregion


    #region Methods
    // Inițializează membrii clasei.
    private void Start()
    {
        _camera = Camera.main;
        ShufflePieces();
    }

    // Amestecă piesele de puzzle.
    private void ShufflePieces()
    {
        List<Slot> freeSlots = _Slots.ToList();
        foreach (PuzzlePiece piece in _VisiblePieces)
        {
            // Exercitiul 1A
        }
    }

    // Metodă apelată la fiecare frame.
    // Folosită pentru selecția pieselor de puzzle.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindPuzzlePiece();
        }
    }

    // Verifică dacă s-a făcut click pe o piesă de puzzle,
    // și o mută dacă este adiacentă câmpului neocupat.
    private void FindPuzzlePiece()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);
        Collider collider = hitInfo.collider;
        if (collider != null)
        {
            PuzzlePiece piece = collider.GetComponent<PuzzlePiece>();
            if (piece != null)
            {
                // Exercițiul 2A
            }
        }
    }

    // Verifică dacă toate piesele de puzzle sunt așezate corect,
    // iar dacă da, termină jocul.
    private void CheckWinCondition()
    {
        // Exercițiul 2B
    }

    // Instanțiază ultima piesă de puzzle, și o plasează pe ultimul câmp.
    private void FinishGame()
    {
        // Exercițiul 2C
    }

    // Resetează jocul.
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Plasează fiecare piesă pe câmpul corect, mai puțin piesa 8,
    // care este plasată pe câmpul 9.
    // Metodă folosită în scopul rezolvării rapide a jocului.
    public void Autosolve()
    {
        for (int index = 0; index < _VisiblePieces.Count - 1; ++index)
        {
            _VisiblePieces[index].SetSlot(_Slots[index]);
        }
        _VisiblePieces.Last().SetSlot(_Slots.Last());
        _Slots[_Slots.Count - 2].SetPiece(null);
    }
    #endregion
}
