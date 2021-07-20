using UnityEngine;

public sealed class CubesBackgroundRotation : MonoBehaviour
{
    [SerializeField] private Transform _cubeTransform;
    [SerializeField] private float _xRotationSpeed, _yRotationSpeed, _zRotationSpeed;

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
        
        /// Fica a dica: se tu vai usar o transform no update como aqui é interessante tu dar um "cache" (guardar em uma variavel) o transform. Pode parecer estranho
        /// mas believe it or not, é mais performatico do que acessar o transform como tu fez aqui embaixo.
        /// Não é algo "game changer" por isso estou sugerindo só neste caso aqui em que estamos no update, em um metodo bem simples.
>>>>>>> code-review-1
        transform.Rotate(new Vector3(_xRotationSpeed, _yRotationSpeed, _zRotationSpeed) * Time.deltaTime);
=======
        ///(Done)
        /// Fica a dica: se tu vai usar o transform no update como aqui é interessante tu dar um "cache" (guardar em uma variavel) o transform. Pode parecer estranho
        /// mas believe it or not, é mais performatico do que acessar o transform como tu fez aqui embaixo.
        /// Não é algo "game changer" por isso estou sugerindo só neste caso aqui em que estamos no update, em um metodo bem simples.
        _cubeTransform.Rotate(new Vector3(_xRotationSpeed, _yRotationSpeed, _zRotationSpeed) * Time.deltaTime);
>>>>>>> Stashed changes
    }
}