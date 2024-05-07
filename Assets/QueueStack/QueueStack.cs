using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QueueStack : MonoBehaviour
{
    public TMP_InputField Ninput;
    public TMP_InputField Ainput; 
    public TMP_InputField Binput; 
    public TMP_InputField Minput; 
    public TMP_InputField Cinput;
    public TMP_Text answerText;

    [Space(10)]
    public List<int> queuestack;
    [Range(1,100000)]
    public int N;       // queuestack�� �����ϴ� �ڷᱸ���� ���� N(1<= N <= 100,000)
    //[Range(0,1)]
    public int[] A; // ���� N�� ���� A�� �־�����. i�� �ڷᱸ���� ť��� Ai = 0, �����̶�� Ai = 1�̴�
    public float[] B; // ���� N�� ���� B�� �־�����. Bi�� i�� �ڷᱸ���� ��� �ִ� �����̴�.(1<= Bi <= 1,000,000,000)
    public int M;       // ������ ������ ���� M�� �־�����. (1 <= M <= 100,000)
    public float[] C; // queuestack�� ������ ���Ҹ� ��� �ִ� ���� M�� ���� C�� �־�����(1<= Ci <= 1,000,000,000)
    public string answer;

    public void QueueStackInput ()
    {
        Initialized();
        N = int.Parse(Ninput.text);
        A = new int[N];
        B = new float[N];
        if(Ainput.text.Split(' ').Length > N)
        {
            answerText.text = "Ainput Error!";
        }
        else
        {
            for(int i = 0; i < N; i++)
            {
                A[i] = int.Parse(Ainput.text.Split(' ')[i]);
            }
        }
        if(Binput.text.Split(' ').Length > N)
        {
            answerText.text += "\nBinput Error!";
        }
        else
        {
            for(int i = 0; i < N; i++)
            {
                B[i] = int.Parse(Binput.text.Split(' ')[i]);
            }
        }
        M = int.Parse(Minput.text);
        C = new float[M];
        if(Cinput.text.Split(' ').Length > M)
        {
            answerText.text += "\nCinput Error!";
        }
        else
        {
            for(int i = 0; i < M; i++)
            {
                C[i] = int.Parse(Cinput.text.Split(' ')[i]);
            }
        }
        Calculate();
    }

    private void Calculate()
    {
        for(int j = 0; j < M; j++)
        {
            float pop = C[j];
            float save;
            for (int i = 0; i < N; i++)
            {
                if(A[i] == 0)   // queue
                {
                    save = B[i];
                    B[i] = pop;
                    pop = save;
                }
                                // stack�� ���� �� �ʿ䰡 �����
            }
            answer += pop + " ";
        }
        answerText.text = answer;
    }

    private void Initialized()
    {
        answerText.text = "";
        Ninput.text = "";
        Ainput.text = "";
        Binput.text = "";
        Minput.text = "";
        Cinput.text = "";
    }
}
