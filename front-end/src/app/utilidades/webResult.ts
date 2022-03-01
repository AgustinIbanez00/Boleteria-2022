export interface webResult {
  result: object;
  success: boolean;
  message: string;
  error_messages: Map<string, string[]>;
  error_code: number;
  error: string;
}

export interface webResultList extends webResult {
  pagination: pagination;
}

export interface pagination {
  has_next_page: boolean;
  has_previous_page: boolean;
  page_index: number;
  total_items: number;
  total_pages: number;
}
