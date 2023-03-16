using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DropDatabase", fileName = "DropDatabase", order = 0)]
public class DropDatabase : SingletonScriptableObject<DropDatabase> {

	public List<MapDropSpawnProbability> allDrops;
	public List<TableReductionRange> tableReductionRanges;

	public Drop GetDrop(float dimension) {
		var lowerRange = GetLowerRange(dimension);
		var random = Random.Range(lowerRange, 1);
		List<Drop> dropList = GetLists(random);
		return dropList[Random.Range(0, dropList.Count)];
	}


	private List<Drop> GetLists(float prob) {
		foreach (var table in allDrops) {
			var tableDimension = table.rangeProbability;
			if (tableDimension.x <= prob && prob <= tableDimension.y) {
				return table.drops;
			}
		}
		return allDrops[0].drops;
	}

	private float GetLowerRange(float dimension) {
		foreach (var table in tableReductionRanges) {
			var tableDimension = table.dimension;
			if (tableDimension.x <= dimension && dimension <= tableDimension.y) {
				return table.lowerRange;
			}
		}
		return 0;
	}


}