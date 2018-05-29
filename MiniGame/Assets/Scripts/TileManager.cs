using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
/*version 0.0
 * 1.검은색과 흰 색 타일 2개의 타일의 Layer를 Floor라고 두었다.
 * 2. 1행, 4행은 흰색과 검정 타일을 고정으로 배치를 시킨다.
 * 3. 2행, 3행은 흰색과 검정 타일을 랜덤으로 배치를 시킨다.
 * 4. 처음엔 4 x 4행렬로 시작 -> 8 x 8 행렬로 키우기
 */

public class TileManager : MonoBehaviour
{
    [Serializable]
    public class Count 
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min; 
            maximum = max;
        }
    }

    public int columns = 5;
    public int rows = 5;
    public GameObject[] floorTiles; //흰색, 검은색 타일을 floorTiles라는 배열안에 넣을 예정.
                                    //Inspector에서 선택하게 될 타일 프리팹으로 위의 배열을 채울 예정.
    private Transform boardHolder; //boardHolder는 Hierarchy를 깨끗이 해놓기 위해 사용할 변수, boardHolder의 자식으로 Object들을 넣는다.
  //  private List<Vector3> gridPositions = new List<Vector3>(); //가능한 모든 다른 위치들을 추적하기 위해 사용(나중에 열쇠찾기 위해서 필요할 듯)
   
         
    void BoardSetup() //To make floorTiles
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = 0; x < columns ; x++)
        { 
            for (int y = 0; y < rows ; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)]; //floorTiles을 Random하게 선택. -> Instance화 & length를 지정할 필요 x

                //안에 부분 처리(1행은 y가 짝수일 때만, 흰색 타일. 홀수 이면, 검은 타일.)
                if(x == 0)
                {
                    if (y % 2 == 0)
                        toInstantiate = floorTiles[0];
                    else
                        toInstantiate = floorTiles[1];
                }
                //안에 부분 처리(3행은 y가 홀수 일 때, 흰색 타일, 짝수 일 땐, 검은 타일)
                if(x == 3)
                {
                    if (y % 2 == 0)
                        toInstantiate = floorTiles[1];
                    else
                        toInstantiate = floorTiles[0];
                }
                //나머지 1,2행은 흰색과 검은색 번갈아 가면서 배치.
                //실제로 인스턴스화 하는 부분
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }
    public void SetupScene() //gameBoard가 make될 때, GameManager에 의해 호출 됨.
    {
        BoardSetup();
    }
}
