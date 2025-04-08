import os
import pandas as pd


def clean_time_series_file(path, is_parquet):
    """
    This function cleans the time series file (CSV or Parquet).

    :param path: The path to the file you want to read.
    :param is_parquet: If True, the file is a Parquet file, otherwise it's a CSV file.
    :return: Returns the cleaned DataFrame, or None if required columns are missing.
    """
    if is_parquet:
        df = pd.read_parquet(path)
    else:
        df = pd.read_csv(path)

    # Adjustment: Use 'mean_value' if 'value' doesn't exist
    if 'value' not in df.columns and 'mean_value' in df.columns:
        df['value'] = df['mean_value']

    if 'timestamp' not in df.columns or 'value' not in df.columns:
        print(f"Required columns are missing in the file {path}")
        return None
    df['timestamp'] = pd.to_datetime(df['timestamp'], errors='coerce')

    df['value'] = pd.to_numeric(df['value'], errors='coerce')
    df = df.dropna(subset=['timestamp', 'value'])
    df = df.drop_duplicates(subset='timestamp')
    return df


def split_by_day(df, path_folder, is_parquet):
    """
    This function splits the DataFrame by day and generates separate files for each day.

    :param df: The cleaned DataFrame.
    :param path_folder: The path where the files will be saved.
    :param is_parquet: If True, the files will be Parquet, otherwise they will be CSV.
    :return: Does not return anything.
    """
    df['date'] = df['timestamp'].dt.date
    os.makedirs(path_folder, exist_ok=True)
    for date, group in df.groupby('date'):
        file_name = os.path.join(path_folder, f"date_{date}.parquet" if is_parquet else f"date_{date}.csv")
        if is_parquet:
            group.to_parquet(file_name, index=False, engine='pyarrow')  # Ensure using pyarrow engine
        else:
            group.to_csv(file_name, index=False)


def avg_value_by_hour(df):
    """
    This function calculates the average value for each hour in the DataFrame.

    :param df: The cleaned DataFrame.
    :return: Returns a DataFrame with average values for each hour.
    """
    df['hour'] = df['timestamp'].dt.floor('h')
    hour_avg_df = df.groupby('hour')['value'].mean().reset_index()
    hour_avg_df.columns = ['start time', 'avg']
    return hour_avg_df


def ex_one(path, is_parquet):
    """
    This function calls `clean_time_series_file` to read and clean the file.

    :param path: The file path.
    :param is_parquet: If the file is a Parquet file.
    :return: Returns the cleaned DataFrame, or None if there's an error.
    """
    return clean_time_series_file(path, is_parquet)


def ex_two(path, split_path, is_parquet):
    """
    This function processes the entire task: reading the file, splitting by day, and calculating hourly averages.

    :param path: The path to the original file.
    :param split_path: The path where split files will be saved.
    :param is_parquet: If True, the process will work with Parquet files, otherwise with CSV files.
    :return: Does not return anything, prints results, and generates files.
    """
    df_clean_file = ex_one(path, is_parquet)
    if df_clean_file is None:
        print(f"Unable to process {path}")
        return

    split_by_day(df_clean_file, split_path, is_parquet)
    file_list = os.listdir(split_path)
    print("\n Splitting the file by day")
    print("Number of files created:", len(file_list))
    print("File names:", file_list)

    all_hourly_averages = []
    for f in file_list:
        full_path = os.path.join(split_path, f)
        df = clean_time_series_file(full_path, is_parquet)
        if df is not None:
            hour_avg = avg_value_by_hour(df)
            all_hourly_averages.append(hour_avg)

    if all_hourly_averages:
        final_df = pd.concat(all_hourly_averages, ignore_index=True)
        print("\nTable of hourly averages for all split files:")
        print(final_df)
        if is_parquet:
            final_df.to_parquet("C:/Users/user1/Desktop/Hadasim5/part1/time_series/avg_all_together_parquet.parquet")
        else:
            final_df.to_csv("C:/Users/user1/Desktop/Hadasim5/part1/time_series/avg_all_together.csv")


# Routes
time_series_path = "C:/Users/user1/Desktop/Hadasim5/part1/time_series/time_series.csv"
split_path = "C:/Users/user1/Desktop/Hadasim5/part1/time_series/split_file"
time_series_parquet_path = "C:/Users/user1/Desktop/Hadasim5/part1/time_series/time_series.parquet"
split_path_parquet = "C:/Users/user1/Desktop/Hadasim5/part1/time_series/time_series_parquet"

#---------- Example 2
ex_two(time_series_path, split_path, False)
print("part 4----- parquet file")
#---------- Example 4
ex_two(time_series_parquet_path, split_path_parquet, True)
