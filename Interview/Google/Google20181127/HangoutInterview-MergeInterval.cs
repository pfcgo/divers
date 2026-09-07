Please use this Google doc to code during your interview. To free your hands for coding, we recommend that you use a headset or a phone with speaker option.

Given an ordered disjoint list of intervals and another interval, construct a union of the intervals, so that the result is also an ordered disjoint list of intervals.

Example:

union([{10, 20}, {25, 28}, {30, 33}, {35, 40}, {50, 60}],
      {23, 38})
    = [{10, 20}, {23, 40}, {50, 60}]


int AddAllLeft( List(int,int) mergedIntervals, int,int)[] intervals, (int, int) newInterval){
if(interval.Length == 0)
return;	

	int i = 0;
	while (i < intervals.Length && intervals[i][1] < nI[0]){
		mergedInterval.Add(interval[i];
		++i;
	}

	return i;
}

int AddMergePart( List(int,int) mergedIntervals, int,int)[] intervals, (int, int) newInterval, int mergeStartI){

var mergedPart = newInterval;

while(mergeStartI < intervals.Length && intervals[mergeSI][0] <= newInterval[1]){
	mergedPart[0] = min(mergedPart[0], intervals[mergeStartI][0]);
	mergedPart[1] = max(mergedPart[1], intervals[mergeStartI][1]);
	mergeStartI++;
}

mergedInterval.Add(mergedPart);

return mergeSi;

	
}

void AddAllRight( List(int,int) mergedIntervals, int,int)[] intervals, (int, int) newInterval, int rightStartI){
	while(rightStartI < intervals.Length){
		mergedIntervals.Add(intervals[rightStartI]);
		rightStartI++;
	}
}


(int,int)[] union((int,int)[] intervals, (int, int) newInterval){
	List<(int,int)> mergedInterval= new ...
	int mergeStartI = AddAllLeft(mergedInterval, intervals, newInt);

	int rightStartI = AddMergePart((mergedInterval, intervals, newInt, mergeStartI );

	AddAllRight(mergedInterval, intervals, newInt, rightStartI);

	return ToArray(mergedInterval);
}
