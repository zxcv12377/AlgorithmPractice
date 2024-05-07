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
    public int N;       // queuestack을 구성하는 자료구조의 개수 N(1<= N <= 100,000)
    //[Range(0,1)]
    public int[] A; // 길이 N의 수열 A가 주어진다. i번 자료구조가 큐라면 Ai = 0, 스택이라면 Ai = 1이다
    public float[] B; // 길이 N의 수열 B가 주어진다. Bi는 i번 자료구조에 들어 있는 원소이다.(1<= Bi <= 1,000,000,000)
    public int M;       // 삽입할 수열의 길이 M이 주어진다. (1 <= M <= 100,000)
    public float[] C; // queuestack에 삽입할 원소를 담고 있는 길이 M의 수열 C가 주어진다(1<= Ci <= 1,000,000,000)
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
                                // stack은 따로 쓸 필요가 없어보임
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
