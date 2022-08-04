using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//extracts spectrum data from the audiolistener
public class SpectrumEngine : MonoBehaviour
{
    [SerializeField]
    float modifier;
 

    float[] m_audioSpectrum;
    [SerializeField]
    float[] m_spectrumrefined;
    public static float SpectrumValue { get; private set; }
    public static float[] SpectrumArray { get; private set; }
    void Start()
    {
        m_audioSpectrum = new float[128];
        m_spectrumrefined = new float[m_audioSpectrum.Length / 4];
        for (int i = 0; i < m_spectrumrefined.Length; i++)
            m_spectrumrefined[i] = 0;
        SpectrumArray = m_spectrumrefined;
     
    }
    public void setModifier(float mod)
    {
        modifier = mod;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(m_audioSpectrum,0,FFTWindow.Hamming);
        if(m_audioSpectrum != null && m_audioSpectrum.Length>0)
        {
            SpectrumValue = ((Mathf.Log(m_audioSpectrum[1] + 10, 2)-3.3f) *  modifier);
            for (int i = 0; i < m_spectrumrefined.Length; i++)
            {
                m_spectrumrefined[i] = (SpectrumArrayRefine(i) - 10.8f) * modifier;
            }
            SpectrumArray = m_spectrumrefined;
        }

    
    }

    public float SpectrumArrayRefine(int SpectrumIndex)
    {
        //quick maffs
        if (m_audioSpectrum == null || SpectrumIndex > m_audioSpectrum.Length) return 0;
        //do spectrum calculations of the element and the next two indexes then average it out of 4
        //maffs
        return (((Mathf.Log(m_audioSpectrum[SpectrumIndex] + 10, 2)) ) + ((Mathf.Log(m_audioSpectrum[SpectrumIndex + 1] + 10, 2))) + 
            ((Mathf.Log(m_audioSpectrum[SpectrumIndex +2] + 10, 2)) )) + ((Mathf.Log(m_audioSpectrum[SpectrumIndex +3] + 10, 2))) / 4;
    }

}

