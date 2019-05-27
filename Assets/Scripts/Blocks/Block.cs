using UnityEngine;

public class Block : MonoBehaviour
{

    [Header("Block Propirties")]
    public bool staticBlock = true;
    public bool randomStartSprite = false;
    public bool mirrorSprite = false;

    public enum BlockMaterial
    {
        Sand,
        LittleGrass,
        BigGrass,
        Rock,
        Ice,
        None
    }

    public enum BlockShape
    {
        Square,
        Long,
        None
    }

    public BlockMaterial material = BlockMaterial.None;
    public BlockShape shape = BlockShape.Square;
    public Sprite hardSetSprite;
    public Sprite[] sprites;

    protected Rigidbody2D rb;
    protected BoxCollider2D cl;

    public virtual void Start()
    {
        LoadSprites();
        name = (material.ToString() + shape.ToString()).ToLower() + (UnityEngine.Random.Range(0, 9999)).ToString();
        cl = gameObject.AddComponent<BoxCollider2D>();
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.isKinematic = staticBlock;

        //Отзеркаливание спрайта, для разнообразия
        GetComponent<SpriteRenderer>().flipX = mirrorSprite;
    }

    void LoadSprites()
    {
        //Если спрайт выставлен принудительно, то включаем его, без подгрузки остальных спрайтов
        if (hardSetSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = hardSetSprite;
            return;
        }
        //Загрузка массива спрайтов из ресурсов
        sprites = Resources.LoadAll<Sprite>("Blocks/" + shape.ToString().ToLower() + "/" + material.ToString().ToLower());
        //Случайный стартовый спрайт
        if (!randomStartSprite)
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        else
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];

    }

    //Функции для редактора
    public void NextSprite()
    {
        Sprite current = GetComponent<SpriteRenderer>().sprite;
        int index = int.Parse(current.name);
        int newIndex = (index + 1) % sprites.Length;
        GetComponent<SpriteRenderer>().sprite = sprites[newIndex];
    }

    public void PrewSprite()
    {
        Sprite current = GetComponent<SpriteRenderer>().sprite;
        int newIndex = 0;
        int index = int.Parse(current.name);
        if (index - 1 < 0) newIndex = sprites.Length - 1;
        else newIndex = index - 1;
        GetComponent<SpriteRenderer>().sprite = sprites[newIndex];
    }

}