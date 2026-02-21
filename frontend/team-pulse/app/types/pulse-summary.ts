export interface TeamPulseSummary {
	count: number;
	averageScore: number;
	scores: Record<string, number>;
	categories: TeamPulseSummaryCategory[];
}

export interface TeamPulseSummaryCategory {
	id: number;
	name: string;
	count: number;
}
