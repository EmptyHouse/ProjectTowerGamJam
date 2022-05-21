using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EHDataTableRow
{
    public string RowId;
}

public class EHDataTable<T> : ScriptableObject where T : EHDataTableRow
{
    [SerializeField]
    private List<T> DataTableRows = new List<T>();
    
    private Dictionary<string, T> DataTableDictionary = new Dictionary<string, T>();

    public virtual void InitializeTable()
    {
        foreach (T DataEntry in DataTableRows)
        {
            DataTableDictionary.Add(DataEntry.RowId, DataEntry);
        }
    }

    /// <summary>
    /// Does a check for duplicates
    /// </summary>
    private void OnValidate()
    {
        if (Application.isPlaying) return;
        
        HashSet<string> DuplicateCheck = new HashSet<string>();
        foreach (T Entry in DataTableRows)
        {
            if (!DuplicateCheck.Add(Entry.RowId))
            {
                Debug.LogError("DuplicateEntry: " + Entry.RowId);
            }
        }
    }

    public T FindEntryWithId(string RowId)
    {
        if (DataTableDictionary.ContainsKey(RowId))
        {
            return DataTableDictionary[RowId];
        }

        return null;
    }
}
